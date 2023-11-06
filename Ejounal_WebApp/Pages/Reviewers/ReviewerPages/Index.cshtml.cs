using BussinessObject.Models;
using BussinessObject.Models.enums;
using DataAccess.Repository;
using Ejounal_WebApp.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ejounal_WebApp.Pages.Reviewers.ReviewerPages
{
    public class IndexModel : PageModel
    {
        const string KEY_SESSION_REVIEWER = "REVIEWER";
        private readonly IUserRepository _userRepository;

        public IndexModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Users Users { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync()
        {
            if (HttpContext.Session.Get<SessionAuthor>("REVIEWER")?.RoleName != RoleName.REVIEWER)
            {
                //Response.Redirect("../../Login");
                return RedirectToPage("../../Login");
            }
            var sessionAuthor = (SessionAuthor)HttpContext.Session.Get<SessionAuthor>(KEY_SESSION_REVIEWER);
            if (sessionAuthor != null)
            {
                var users = _userRepository.GetById(sessionAuthor.UserId);
                if (users == null)
                {
                    return NotFound();
                }
                else
                {
                    Users = users;
                }
            }
            return Page();
        }
    }
}
