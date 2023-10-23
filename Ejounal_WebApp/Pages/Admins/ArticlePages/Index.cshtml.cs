﻿using BussinessObject.Models;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ejounal_WebApp.Pages.Admins.ArticlePages
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
            Articles = _articlesRepository.GetAll().ToList();
        }
    }
}