﻿using System.Linq;
using System.Threading.Tasks;
using EC_Website.Core.Entities.BlogModel;
using EC_Website.Core.Entities.UserModel;
using EC_Website.Core.Interfaces;
using EC_Website.Infrastructure.Data;

namespace EC_Website.Infrastructure.Repositories
{
    public class BlogRepository : Repository, IBlogRepository
    {
        private readonly ApplicationDbContext _context;

        public BlogRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task UpdateTagsAsync(Blog blog, bool saveChanges = true, params Tag[] tags)
        {
            foreach (var tag in tags)
            {
                // ReSharper disable once SpecifyStringComparison
                var originTag = await GetAsync<Tag>(i => i.Name.ToLower() == tag.Name.ToLower());

                if (originTag == null)
                {
                    originTag = new Tag(tag);
                    await _context.Set<Tag>().AddAsync(originTag);
                }

                // ReSharper disable once SpecifyStringComparison
                if (blog.BlogTags.Any(i => i.Tag.Name.ToLower() == originTag.Name.ToLower()))
                {
                    continue;
                }

                blog.BlogTags.Add(new BlogTag
                {
                    Tag = originTag
                });
            }

            if (saveChanges)
            {
                await UpdateAsync(blog);
            }
        }

        public Task AddLikeAsync(Blog blog, ApplicationUser user)
        {
            if (blog == null || user == null)
            {
                return Task.CompletedTask;
            }

            if (blog.LikedUsers.All(i => i.UserId != user.Id && i.BlogId == blog.Id))
            {
                blog.LikedUsers.Add(new BlogLike()
                {
                    Blog = blog,
                    User = user
                });
            }

            return UpdateAsync(blog);
        }

        public Task RemoveLikeAsync(Blog blog, ApplicationUser user)
        {
            if (blog == null || user == null)
            {
                return Task.CompletedTask;
            }

            var blogLike = _context.Set<BlogLike>().FirstOrDefault(i => i.UserId == user.Id && i.BlogId == blog.Id);

            if (blogLike == null) 
                return Task.CompletedTask;

            blog.LikedUsers.Remove(blogLike);
            return UpdateAsync(blog);
        }

        public async Task DeleteBlogAsync(Blog blog)
        {
            foreach (var comment in blog.Comments)
            {
                await DeleteCommentAsync(comment, false);
            }

            await DeleteAsync(blog);
        }

        public async Task DeleteCommentAsync(Comment comment, bool saveChanges = true)
        {
            await RemoveChildrenCommentsAsync(comment);
            var rootComment = _context.Set<Comment>().FirstOrDefault(i => i.Id == comment.Id);

            if (rootComment != null)
            {
                _context.Remove(rootComment);
            }

            if (saveChanges)
            {
                await _context.SaveChangesAsync();
            }
        }

        private async Task RemoveChildrenCommentsAsync(Comment comment)
        {
            foreach (var reply in comment.Replies)
            {
                await RemoveChildrenCommentsAsync(reply);
                _context.Remove(reply);
            }
        }
    }
}
