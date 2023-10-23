using BussinessObject.Models;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ejounal_WebApp.Pages.Reviewers.ArticlesReviewer
{
    public class EditModel : PageModel
    {
        private readonly IArticlesRepository _articlesRepository;
        private readonly IJournalRepository _journalRepository;

        public EditModel(IArticlesRepository articlesRepository, IJournalRepository journalRepository)
        {
            _articlesRepository = articlesRepository;
            _journalRepository = journalRepository;
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
            Articles = articles;
            ViewData["JournalsId"] = new SelectList(_journalRepository.GetAll(), "Id", "Name");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var tmpArticle = _articlesRepository.GetById(Articles.Id);
            if (tmpArticle != null)
            {
                tmpArticle.Status = Articles.Status;
                _articlesRepository.Update(tmpArticle);
            }

            return RedirectToPage("./Index");
        }

    }
}
