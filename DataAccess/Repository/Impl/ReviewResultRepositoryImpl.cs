using BussinessObject.Data;
using BussinessObject.Models;

namespace DataAccess.Repository.Impl;
public class ReviewResultRepositoryImpl : IReviewResultRepository
{
    private readonly ApplicationContext _context;

    public ReviewResultRepositoryImpl(ApplicationContext context)
    {
        _context = context;
    }

    public void AddReviewResult(ReviewResult reviewResult)
    {
        _context.ReviewResults.Add(reviewResult);
        _context.SaveChanges();
    }

    public IEnumerable<ReviewResult> GetAll()
    {
        return _context.Set<ReviewResult>();
    }

    public ReviewResult GetReviewResult(int articleId, int userId)
        => _context.ReviewResults.FirstOrDefault(rr => rr.ArticlesId == articleId && rr.UsersId == userId);
}
