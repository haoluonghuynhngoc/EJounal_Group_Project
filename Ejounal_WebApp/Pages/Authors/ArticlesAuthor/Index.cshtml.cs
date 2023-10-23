using BussinessObject.Models;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ejounal_WebApp.Pages.Authors.ArticlesAuthor
{
    public class IndexModel : PageModel
    {
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
            var author = _userRepository.GetById(1); // truyen ve id cua user trong session
            if (author != null)
            {
                Articles = new List<Articles>();
                foreach (var articleObject in author.Contributors)
                {
                    Articles.Add(articleObject.Articles);
                }
            }
            return Page();
        }
    }
}
