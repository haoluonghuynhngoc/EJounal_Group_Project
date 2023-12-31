﻿using BussinessObject.Data;
using BussinessObject.Models;

namespace DataAccess.Repository.Impl;
public class ArticlesRepositoryImpl : RepositoryBaseImpl<Articles>, IArticlesRepository
{
    private readonly ApplicationContext _context;

    public ArticlesRepositoryImpl(ApplicationContext context) : base(context)
    {
        _context = context;
    }

    public bool FindArticleTitle(string title)
    {
        return _context.Articles.Any(a => a.Title == title);
    }
}
