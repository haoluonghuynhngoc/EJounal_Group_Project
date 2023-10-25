using BussinessObject.Models;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ejounal_WebApp.Pages.Admins.ArticlePages
{
    public class EditModel : PageModel
    {
        private readonly IArticlesRepository _articlesRepository;
        private readonly IJournalRepository _journalRepository;
        private readonly IFieldsRepository _fieldsRepository;

        public EditModel(IArticlesRepository articlesRepository, IJournalRepository journalRepository, IFieldsRepository fieldsRepository)
        {
            _articlesRepository = articlesRepository;
            _journalRepository = journalRepository;
            _fieldsRepository = fieldsRepository;
        }

        [BindProperty]
        public Articles Articles { get; set; } = default!;
        [BindProperty]
        public Fields Fields { get; set; } = default!;

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
            ViewData["FiedsId"] = new SelectList(_fieldsRepository.GetAll(), "Id", "Name");
            ViewData["JournalsId"] = new SelectList(_journalRepository.GetAll(), "Id", "Name");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            ViewData["FiedsId"] = new SelectList(_fieldsRepository.GetAll(), "Id", "Name");
            ViewData["JournalsId"] = new SelectList(_journalRepository.GetAll(), "Id", "Name");
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (_articlesRepository.FindArticleTitle(Articles.Title))
            {
                ModelState.AddModelError("Articles.Title", "Title already exist");
                return Page();
            }
            var tmpArticle = _articlesRepository.GetById(Articles.Id);
            if (tmpArticle != null)
            {
                //tmpArticle.ArticleFields.Add
                tmpArticle.Images = Articles.Images;
                tmpArticle.Description = Articles.Description;
                tmpArticle.Title = Articles.Title;
                tmpArticle.SortDescription = Articles.SortDescription;
                _articlesRepository.Update(tmpArticle);
            }

            return RedirectToPage("./Index");
        }

    }
}
