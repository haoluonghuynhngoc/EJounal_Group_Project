using BussinessObject.Models;
using BussinessObject.Models.enums;
using DataAccess.Repository;
using Ejounal_WebApp.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ejounal_WebApp.Pages.Authors.ArticlesAuthor
{
    public class DetailsModel : PageModel
    {
        private readonly IArticlesRepository _articlesRepository;

        public DetailsModel(IArticlesRepository articlesRepository)
        {
            _articlesRepository = articlesRepository;
        }

        public Articles Articles { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (HttpContext.Session.Get<SessionAuthor>("AUTHOR")?.RoleName != RoleName.AUTHOR)
            {
                //Response.Redirect("../../Login");
                return RedirectToPage("../../Login");
            }
            if (id == null)
            {
                return NotFound();
            }

            var articles = _articlesRepository.GetById((int)id);
            if (articles == null)
            {
                return NotFound();
            }
            else
            {
                Articles = articles;
            }
            return Page();
        }
    }
}
