using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ejounal_WebApp.Pages
{
    public class LogoutModel : PageModel
    {
        public void OnGet()
        {
        }
        public IActionResult OnPost(string confirm)
        {
            if (confirm == "yes")
            {
                HttpContext.Session.Clear();

            }
            return RedirectToPage("./Index");
        }
    }
}
