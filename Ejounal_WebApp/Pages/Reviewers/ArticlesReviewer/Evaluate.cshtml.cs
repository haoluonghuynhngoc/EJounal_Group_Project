using BussinessObject.Models;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ejounal_WebApp.Pages.Reviewers.ArticlesReviewer
{
    public class EvaluateModel : PageModel
    {

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
            // lay session User
            if (!ModelState.IsValid)
            {
                return Page();
            }
            ReviewResult.Articles = _articlesRepository.GetById(Articles.Id);
            ReviewResult.Users = _userRepository.GetById(1); //set lai session
            ReviewResult.ReviewDate = DateTime.Now;
            _reviewResultRepository.AddReviewResult(ReviewResult);

            // check o day
            return RedirectToPage("./Index");
        }
    }
}
