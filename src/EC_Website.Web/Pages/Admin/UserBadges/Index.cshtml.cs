using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EC_Website.Core.Entities.User;
using EC_Website.Core.Interfaces;

namespace EC_Website.Web.Pages.Admin.UserBadges
{
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class IndexModel : PageModel
    {
        private readonly IRepository<Badge> _repository;

        public IndexModel(IRepository<Badge> repository)
        {
            _repository = repository;
        }

        public IList<Badge> Badges { get;set; }

        public async Task OnGetAsync()
        {
            Badges = await _repository.GetListAsync();
        }
    }
}
