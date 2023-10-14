using BussinessObject.Data;
using BussinessObject.Models;

namespace DataAccess.Repository.Impl;
public class ArticlesRatingRepositoryImpl : RepositoryBaseImpl<ArticlesRating>, IArticlesRatingRepository
{
    private readonly ApplicationContext _context;

    public ArticlesRatingRepositoryImpl(ApplicationContext context) : base(context)
    {
        _context = context;
    }
}
