﻿using BussinessObject.Models;
using BussinessObject.Models.enums;
using DataAccess.Repository;
using Ejounal_WebApp.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ejounal_WebApp.Pages.Authors.ArticlesAuthor
{
    public class EditModel : PageModel
    {
        private readonly IArticlesRepository _articlesRepository;
        private readonly IJournalRepository _journalRepository;
        private readonly IFieldsRepository _fieldsRepository;

        public EditModel(IArticlesRepository articlesRepository, IJournalRepository journalRepository, IFieldsRepository fieldsRepository)
        {
            _articlesRepository = articlesRepository;
            _journalRepository = journalRepository;
            _fieldsRepository = fieldsRepository;
        }

        [BindProperty]
        public Articles Articles { get; set; } = default!;
        [BindProperty]
        public Fields Fields { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (HttpContext.Session.Get<SessionAuthor>("AUTHOR")?.RoleName != RoleName.AUTHOR)
            {
                // Response.Redirect("../../Login");
                return RedirectToPage("../../Login");
            }
            if (id == null)
            {
                return NotFound();
            }

            var articles = _articlesRepository.GetById((int)id);
            if (articles == null)
            {
                return NotFound();
            }
            Articles = articles;
            ViewData["FiedsId"] = new SelectList(_fieldsRepository.GetAll(), "Id", "Name");
            ViewData["JournalsId"] = new SelectList(_journalRepository.GetAll(), "Id", "Name");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            ViewData["FiedsId"] = new SelectList(_fieldsRepository.GetAll(), "Id", "Name");
            ViewData["JournalsId"] = new SelectList(_journalRepository.GetAll(), "Id", "Name");
            var tmpArticle = _articlesRepository.GetById(Articles.Id);

            if (tmpArticle != null)
            {
                //tmpArticle.ArticleFields.Add
                tmpArticle.Images = Articles.Images;
                tmpArticle.Description = Articles.Description;
                tmpArticle.Title = Articles.Title;
                tmpArticle.Status = ArticleStatus.REVISED;
                tmpArticle.SortDescription = Articles.SortDescription;
                tmpArticle.ReviewResults = new List<ReviewResult>();
                _articlesRepository.Update(tmpArticle);
            }

            return RedirectToPage("./Index");
        }
    }
}
