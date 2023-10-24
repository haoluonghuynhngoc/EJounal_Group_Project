using BussinessObject.Models;
using BussinessObject.Models.enums;
using DataAccess.Repository;
using Ejounal_WebApp.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ejounal_WebApp.Pages.Admins.ArticlePages
{
    public class CreateModel : PageModel
    {
        const string KEY_SESSION_ADMIN = "ADMIN";
        private readonly IArticlesRepository _articlesRepository;
        private readonly IJournalRepository _journalRepository;
        private readonly IFieldsRepository _fieldsRepository;
        private readonly IUserRepository _userRepository;

        public CreateModel(IArticlesRepository articlesRepository, IJournalRepository journalRepository
            , IFieldsRepository fieldsRepository, IUserRepository userRepository)
        {
            _articlesRepository = articlesRepository;
            _journalRepository = journalRepository;
            _fieldsRepository = fieldsRepository;
            _userRepository = userRepository;
        }

        [BindProperty]
        public Articles Articles { get; set; } = default!;
        [BindProperty]
        public Fields Fields { get; set; } = default!;
        public IActionResult OnGet()
        {
            ViewData["FiedsId"] = new SelectList(_fieldsRepository.GetAll(), "Id", "Name");
            ViewData["JournalsId"] = new SelectList(_journalRepository.GetAll(), "Id", "Name");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || Articles == null)
            {
                return Page();
            }
            if (_articlesRepository.FindArticleTitle(Articles.Title))
            {
                ModelState.AddModelError("Articles.Title", "You have already title this article");
                ViewData["FiedsId"] = new SelectList(_fieldsRepository.GetAll(), "Id", "Name");
                ViewData["JournalsId"] = new SelectList(_journalRepository.GetAll(), "Id", "Name");
                return Page();
            }

            var tmpFile = _fieldsRepository.GetById(Fields.Id);
            if (tmpFile != null)
            {
                Articles.ArticleFields = new List<ArticleFields> { new ArticleFields { Fields = tmpFile } };
            }
            var sessionAdmin = (SessionAuthor)HttpContext.Session.Get<SessionAuthor>(KEY_SESSION_ADMIN);
            if (sessionAdmin != null)
            {
                var tmpUser = _userRepository.GetById(sessionAdmin.UserId);
                if (tmpUser != null)
                {
                    Articles.Contributors = new List<Contributors> { new Contributors { Users = tmpUser } };
                }
            }
            Articles.CreateAt = DateTime.Now;
            Articles.UpdateAt = DateTime.Now;
            Articles.Status = ArticleStatus.PENDING;
            _articlesRepository.Add(Articles);
            return RedirectToPage("./Index");
        }
    }
}
