﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using EC_Website.Core.Interfaces;

namespace EC_Website.Web.Pages.Wiki.Category
{
    [Authorize(Roles = "SuperAdmin,Admin,Editor")]
    public class DeleteCategoryModel : PageModel
    {
        private readonly IRepository _repository;

        public DeleteCategoryModel(IRepository repository)
        {
            _repository = repository;
        }

        [BindProperty]
        public Core.Entities.Wikipedia.Category Category { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category = await _repository.GetByIdAsync<Core.Entities.Wikipedia.Category>(id);

            if (Category == null)
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

            Category = await _repository.GetByIdAsync<Core.Entities.Wikipedia.Category>(id);
            await _repository.DeleteAsync(Category);
            return RedirectToPage("./List");
        }
    }
}