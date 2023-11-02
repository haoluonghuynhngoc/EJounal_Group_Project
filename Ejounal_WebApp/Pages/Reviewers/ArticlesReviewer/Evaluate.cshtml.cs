using BussinessObject.Models;
using BussinessObject.Models.enums;
using DataAccess.Repository;
using Ejounal_WebApp.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ejounal_WebApp.Pages.Reviewers.ArticlesReviewer
{
    public class EvaluateModel : PageModel
    {
        const string KEY_SESSION_REVIEWER = "REVIEWER";
        private readonly IArticlesRepository _articlesRepository;
        private readonly IUserRepository _userRepository;
        private readonly IReviewResultRepository _reviewResultRepository;

        public EvaluateModel(IArticlesRepository articlesRepository, IUserRepository userRepository, IReviewResultRepository reviewResultRepository)
        {
            _articlesRepository = articlesRepository;
            _userRepository = userRepository;
            _reviewResultRepository = reviewResultRepository;
        }

        [BindProperty]
        public Articles Articles { get; set; } = default!;
        [BindProperty]
        public ReviewResult ReviewResult { get; set; } = default!;

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

            //ViewData["ArticlesId"] = new SelectList(_articlesRepository.GetAll(), "Id", "Description");
            //ViewData["UsersId"] = new SelectList(_userRepository.GetAll(), "Id", "Address");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            ReviewResult.Articles = _articlesRepository.GetById(Articles.Id);
            var sessionReviewer = (SessionAuthor)HttpContext.Session.Get<SessionAuthor>(KEY_SESSION_REVIEWER);
            if (sessionReviewer != null)
            {
                ReviewResult.Users = _userRepository.GetById(sessionReviewer.UserId);
            }
            ReviewResult.ReviewDate = DateTime.Now;
            try
            {
                _reviewResultRepository.AddReviewResult(ReviewResult);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("Error", "You have already rated this article");
                return Page();
            }

            // co 5 result thi chap nhan
            // sua o && rr.Articles.Status != ArticleStatus.APPROVED
            if (_reviewResultRepository.GetAll()
                                       .Where(rr => rr.ArticlesId == Articles.Id && rr.Articles.Status != ArticleStatus.APPROVED)
                                       .Count(rr => rr.Status == ReviewResultStatus.VALID) >= 5)
            {
                var tmpArticleApproved = _articlesRepository.GetById(Articles.Id);
                if (tmpArticleApproved != null)
                {
                    tmpArticleApproved.Status = ArticleStatus.APPROVED;
                    _articlesRepository.Update(tmpArticleApproved);
                }
            }
            else if (_reviewResultRepository.GetAll()
                                            .Where(rr => rr.ArticlesId == Articles.Id && rr.Articles.Status != ArticleStatus.APPROVED)
                                            .Count(rr => rr.Status == ReviewResultStatus.INVALID) >= 5)
            {
                var tmpArticleRejected = _articlesRepository.GetById(Articles.Id);
                if (tmpArticleRejected != null)
                {
                    tmpArticleRejected.Status = ArticleStatus.REJECTED;
                    _articlesRepository.Update(tmpArticleRejected);
                }
            }

            return RedirectToPage("./Index");
        }
    }
}
