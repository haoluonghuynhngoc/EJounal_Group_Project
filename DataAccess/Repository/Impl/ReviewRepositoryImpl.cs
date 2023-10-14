using BussinessObject.Data;
using BussinessObject.Models;

namespace DataAccess.Repository.Impl;
public class ReviewRepositoryImpl : RepositoryBaseImpl<Review>, IReviewRepository
{
    private readonly ApplicationContext _context;

    public ReviewRepositoryImpl(ApplicationContext context) : base(context)
    {
        _context = context;
    }
}
