using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BussinessObject.Data;
using BussinessObject.Models;

namespace Ejounal_WebApp.Pages.Reviewers.Test
{
    public class DetailsModel : PageModel
    {
        private readonly BussinessObject.Data.ApplicationContext _context;

        public DetailsModel(BussinessObject.Data.ApplicationContext context)
        {
            _context = context;
        }

      public ReviewResult ReviewResult { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ReviewResults == null)
            {
                return NotFound();
            }

            var reviewresult = await _context.ReviewResults.FirstOrDefaultAsync(m => m.UsersId == id);
            if (reviewresult == null)
            {
                return NotFound();
            }
            else 
            {
                ReviewResult = reviewresult;
            }
            return Page();
        }
    }
}
