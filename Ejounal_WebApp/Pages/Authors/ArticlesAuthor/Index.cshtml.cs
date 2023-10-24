using BussinessObject.Models;
using DataAccess.Repository;
using Ejounal_WebApp.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ejounal_WebApp.Pages.Authors.ArticlesAuthor
{
    public class IndexModel : PageModel
    {
        const string KEY_SESSION_AUTHOR = "AUTHOR";
        private readonly IArticlesRepository _articlesRepository;
        private readonly IUserRepository _userRepository;

        public IndexModel(IArticlesRepository articlesRepository, IUserRepository userRepository)
        {
            _articlesRepository = articlesRepository;
            _userRepository = userRepository;
        }

        public IList<Articles> Articles { get; set; } = default!;

        public IActionResult OnGetAsync()
        {
            var sessionAuthor = (SessionAuthor)HttpContext.Session.Get<SessionAuthor>(KEY_SESSION_AUTHOR);
            if (sessionAuthor != null)
            {
                var author = _userRepository.GetById(sessionAuthor.UserId);
                if (author != null)
                {
                    Articles = new List<Articles>();
                    foreach (var articleObject in author.Contributors)
                    {
                        Articles.Add(articleObject.Articles);
                    }
                }
            }
            return Page();
        }
    }
}
