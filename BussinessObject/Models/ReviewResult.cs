namespace BussinessObject.Models;
public class ReviewResult
{
    public int UsersId { get; set; }
    public Users Users { get; set; }
    public int ArticlesId { get; set; }
    public Articles Articles { get; set; }
    public string Comment { get; set; }
    public DateTime ReviewDate { get; set; }
}
