using BussinessObject.Models;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ejounal_WebApp.Pages.Admins.ArticlePages
{
    public class DeleteModel : PageModel
    {
        private readonly IArticlesRepository _articlesRepository;

        public DeleteModel(IArticlesRepository articlesRepository)
        {
            _articlesRepository = articlesRepository;
        }

        [BindProperty]
        public Articles Articles { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var articles = _articlesRepository.GetById((int)id);

            if (articles != null)
            {
                _articlesRepository.Delete((int)id);
            }

            return RedirectToPage("./Index");
        }
    }
}
