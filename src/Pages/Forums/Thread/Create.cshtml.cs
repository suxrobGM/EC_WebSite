﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EC_Website.Models.ForumModel;
using EC_Website.Data;

namespace EC_Website.Pages.Forums.Thread
{
    public class CreateThreadModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<Models.UserModel.User> _userManager;

        public CreateThreadModel(ApplicationDbContext db, UserManager<Models.UserModel.User> userManager)
        {
            _db = db;
            _userManager = userManager;
        }     

        [BindProperty]
        public InputModel Input { get; set; }

        public Models.ForumModel.Board Board { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Topic name required")]
            public string Topic { get; set; }

            [Required(ErrorMessage = "Topic text required")]
            [DataType(DataType.MultilineText)]
            public string Text { get; set; }
        }        
        

        public IActionResult OnGet()
        {
            var boardId = RouteData.Values["boardId"].ToString();
            Board = _db.Boards.Where(i => i.Id == boardId).First();

            ViewData.Add("toolbars", new string[]
            {
                "Bold", "Italic", "Underline", "StrikeThrough",
                "FontName", "FontSize", "FontColor", "BackgroundColor",
                "LowerCase", "UpperCase", "|",
                "Formats", "Alignments", "OrderedList", "UnorderedList",
                "Outdent", "Indent", "|",
                "CreateTable", "CreateLink", "Image", "|", "ClearFormat", "Print",
                "SourceCode", "FullScreen", "|", "Undo", "Redo"
            });

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var boardId = RouteData.Values["boardId"].ToString();
            var currentUser = await _userManager.GetUserAsync(User);
            var author = _db.Users.Where(i => i.Id == currentUser.Id).First();
            var board = _db.Boards.Where(i => i.Id == boardId).First();

            var thread = new Models.ForumModel.Thread()
            {
                Author = author,
                Name = Input.Topic,
                Board = board
            };

            var post = new Post()
            {
                Author = author,
                Text = Input.Text,
                Thread = thread,
                Timestamp = DateTime.Now
            };

            thread.Posts.Add(post);
            thread.GenerateUrl();
            _db.Threads.Add(thread);            
            await _db.SaveChangesAsync();

            return RedirectToPage($"/Forums/Thread/Index", new { threadUrl = thread.Url });
        }
    }
}