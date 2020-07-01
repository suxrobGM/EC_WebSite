﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EC_Website.Core.Interfaces;

namespace EC_Website.Web.Pages.Forums.Board
{
    [Authorize(Roles = "SuperAdmin,Admin,Moderator")]
    public class DeleteModel : PageModel
    {
        private readonly IForumRepository _forumRepository;

        public DeleteModel(IForumRepository forumRepository)
        {
            _forumRepository = forumRepository;
        }

        [BindProperty]
        public Core.Entities.Forum.Board Board { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Board = await _forumRepository.GetByIdAsync<Core.Entities.Forum.Board>(id);

            if (Board == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Board = await _forumRepository.GetByIdAsync<Core.Entities.Forum.Board>(id);
            await _forumRepository.DeleteBoardAsync(Board);
            return RedirectToPage("/Index");
        }
    }
}
