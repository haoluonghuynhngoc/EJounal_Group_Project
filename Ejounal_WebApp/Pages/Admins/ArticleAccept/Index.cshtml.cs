using BussinessObject.Models;
using BussinessObject.Models.enums;
using DataAccess.Repository;
using Ejounal_WebApp.Utils;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ejounal_WebApp.Pages.Admins.ArticleAccept
{
    public class IndexModel : PageModel
    {
        private readonly IArticlesRepository _articlesRepository;

        public IndexModel(IArticlesRepository articlesRepository)
        {
            _articlesRepository = articlesRepository;
        }

        public IList<Articles> Articles { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (HttpContext.Session.Get<SessionAuthor>("ADMIN")?.RoleName != RoleName.ADMIN)
            {
                Response.Redirect("../../Login");
                return;
            }
            Articles = _articlesRepository.GetAll().Where(a => a.Status == ArticleStatus.PENDING
                                                       || a.Status == ArticleStatus.REVISED).ToList();
        }
    }
}
