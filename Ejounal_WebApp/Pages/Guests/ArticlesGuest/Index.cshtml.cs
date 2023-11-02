using BussinessObject.Models;
using BussinessObject.Models.enums;
using DataAccess.Repository;
using Ejounal_WebApp.Utils;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ejounal_WebApp.Pages.Guests.ArticlesGuest
{
    public class IndexModel : PageModel
    {
        public PaginatedList<Articles> Articles { get; set; }

        private readonly IArticlesRepository _articlesRepository;

        public IndexModel(IArticlesRepository articlesRepository)
        {
            _articlesRepository = articlesRepository;
        }
        // get all khong phan trang
        //public IList<Articles> Articles { get; set; } = default!;

        //public async Task OnGetAsync()
        //{
        //    Articles = _articlesRepository.GetAll().ToList();
        //} .Where(a => a.Status == ArticleStatus.APPROVED)
        public async Task OnGetAsync(int? PageIndex)
        {
            var PageSize = 3;
            Articles = await PaginatedList<Articles>.CreateAsync(_articlesRepository.GetAll()
               .AsQueryable().Where(a => a.Status == ArticleStatus.APPROVED), PageIndex ?? 1, PageSize);
        }
    }
}
