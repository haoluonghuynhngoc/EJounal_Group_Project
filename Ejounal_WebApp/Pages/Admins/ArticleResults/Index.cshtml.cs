using BussinessObject.Models;
using BussinessObject.Models.enums;
using DataAccess.Repository;
using Ejounal_WebApp.Utils;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ejounal_WebApp.Pages.Admins.ArticleResults
{
    public class IndexModel : PageModel
    {
        private readonly IReviewResultRepository reviewResultRepository;

        public IndexModel(IReviewResultRepository reviewResultRepository)
        {
            this.reviewResultRepository = reviewResultRepository;
        }

        public PaginatedList<ReviewResult> ReviewResult { get; set; } = default!;
        public async Task OnGetAsync(int? PageIndex)
        {
            if (HttpContext.Session.Get<SessionAuthor>("ADMIN")?.RoleName != RoleName.ADMIN)
            {
                Response.Redirect("../../Login");
                return;
            }
            var PageSize = 10;
            ReviewResult = await PaginatedList<ReviewResult>.CreateAsync(reviewResultRepository.GetAll()
               .AsQueryable(), PageIndex ?? 1, PageSize);
        }
    }
}
