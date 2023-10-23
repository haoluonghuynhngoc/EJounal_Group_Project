using BussinessObject.Models;

namespace DataAccess.Repository;
public interface IReviewResultRepository
{
    IEnumerable<ReviewResult> GetAll();
    ReviewResult GetReviewResult(int articleId, int userId);
    void AddReviewResult(ReviewResult reviewResult);
}
