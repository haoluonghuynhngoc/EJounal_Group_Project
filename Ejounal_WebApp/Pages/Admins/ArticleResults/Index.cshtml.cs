using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BussinessObject.Data;
using BussinessObject.Models;

namespace Ejounal_WebApp.Pages.Admins.ArticleResults
{
    public class IndexModel : PageModel
    {
        private readonly BussinessObject.Data.ApplicationContext _context;

        public IndexModel(BussinessObject.Data.ApplicationContext context)
        {
            _context = context;
        }

        public IList<ReviewResult> ReviewResult { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ReviewResults != null)
            {
                ReviewResult = await _context.ReviewResults
                .Include(r => r.Articles)
                .Include(r => r.Users).ToListAsync();
            }
        }
    }
}
