using BussinessObject.Models;
using BussinessObject.Models.enums;
using Ejounal_WebApp.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Ejounal_WebApp.Pages.Admins.ArticleResults
{
    public class DetailsModel : PageModel
    {
        private readonly BussinessObject.Data.ApplicationContext _context;

        public DetailsModel(BussinessObject.Data.ApplicationContext context)
        {
            _context = context;
        }

        public ReviewResult ReviewResult { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (HttpContext.Session.Get<SessionAuthor>("ADMIN")?.RoleName != RoleName.ADMIN)
            {
                //Response.Redirect("../../Login");
                return RedirectToPage("../../Login");
            }
            if (id == null || _context.ReviewResults == null)
            {
                return NotFound();
            }

            var reviewresult = await _context.ReviewResults.FirstOrDefaultAsync(m => m.UsersId == id);
            if (reviewresult == null)
            {
                return NotFound();
            }
            else
            {
                ReviewResult = reviewresult;
            }
            return Page();
        }
    }
}
