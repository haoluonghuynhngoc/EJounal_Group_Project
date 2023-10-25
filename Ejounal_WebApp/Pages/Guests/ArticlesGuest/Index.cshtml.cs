using BussinessObject.Models;
using DataAccess.Repository;
using Ejounal_WebApp.Utils;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

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
        //}
        public async Task OnGetAsync(int? PageIndex)
        {
            var PageSize = 3;
            Articles = await PaginatedList<Articles>.CreateAsync(_articlesRepository.GetAll()
                                                                 .AsQueryable().AsNoTracking(), PageIndex ?? 1, PageSize);
        }
    }
}
