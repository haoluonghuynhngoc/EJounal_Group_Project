using BussinessObject.Models;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ejounal_WebApp.Pages.Guests.ArticlesGuest
{
    public class IndexModel : PageModel
    {
        //public PaginatedList<Articles> Article { get; set; }
        //public string CurrentSearchString { get; set; }

        private readonly IArticlesRepository _articlesRepository;

        public IndexModel(IArticlesRepository articlesRepository)
        {
            _articlesRepository = articlesRepository;
        }

        public IList<Articles> Articles { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Articles = _articlesRepository.GetAll().ToList();
        }
    }
}
