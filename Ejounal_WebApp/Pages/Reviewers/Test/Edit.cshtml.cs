using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BussinessObject.Data;
using BussinessObject.Models;

namespace Ejounal_WebApp.Pages.Reviewers.Test
{
    public class EditModel : PageModel
    {
        private readonly BussinessObject.Data.ApplicationContext _context;

        public EditModel(BussinessObject.Data.ApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ReviewResult ReviewResult { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ReviewResults == null)
            {
                return NotFound();
            }

            var reviewresult =  await _context.ReviewResults.FirstOrDefaultAsync(m => m.UsersId == id);
            if (reviewresult == null)
            {
                return NotFound();
            }
            ReviewResult = reviewresult;
           ViewData["ArticlesId"] = new SelectList(_context.Articles, "Id", "Description");
           ViewData["UsersId"] = new SelectList(_context.Users, "Id", "Address");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ReviewResult).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReviewResultExists(ReviewResult.UsersId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ReviewResultExists(int id)
        {
          return (_context.ReviewResults?.Any(e => e.UsersId == id)).GetValueOrDefault();
        }
    }
}
