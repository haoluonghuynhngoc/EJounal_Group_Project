using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BussinessObject.Data;
using BussinessObject.Models;

namespace Ejounal_WebApp.Pages.Reviewers.Test
{
    public class CreateModel : PageModel
    {
        private readonly BussinessObject.Data.ApplicationContext _context;

        public CreateModel(BussinessObject.Data.ApplicationContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ArticlesId"] = new SelectList(_context.Articles, "Id", "Description");
        ViewData["UsersId"] = new SelectList(_context.Users, "Id", "Address");
            return Page();
        }

        [BindProperty]
        public ReviewResult ReviewResult { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.ReviewResults == null || ReviewResult == null)
            {
                return Page();
            }

            _context.ReviewResults.Add(ReviewResult);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
