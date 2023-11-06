using BussinessObject.Models;
using BussinessObject.Models.enums;
using DataAccess.Repository;
using Ejounal_WebApp.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ejounal_WebApp.Pages.Admins.UserPages
{
    public class DetailsModel : PageModel
    {
        private readonly IUserRepository _userRepository;

        public DetailsModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Users Users { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (HttpContext.Session.Get<SessionAuthor>("ADMIN")?.RoleName != RoleName.ADMIN)
            {
                // Response.Redirect("../../Login");
                return RedirectToPage("../../Login");
            }
            if (id == null)
            {
                return NotFound();
            }

            var users = _userRepository.GetById((int)id);
            if (users == null)
            {
                return NotFound();
            }
            else
            {
                Users = users;
            }
            return Page();
        }
    }
}
