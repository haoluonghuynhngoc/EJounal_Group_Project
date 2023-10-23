using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ejounal_WebApp.Pages;
public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
    //public IActionResult OnGet()
    //{
    //    return RedirectToPage("/Shoes/Index");
    //}
}
