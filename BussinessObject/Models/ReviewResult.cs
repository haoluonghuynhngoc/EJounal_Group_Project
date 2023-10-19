using BussinessObject.Models.enums;

namespace BussinessObject.Models;
public class ReviewResult
{
    public int UsersId { get; set; }
    public virtual Users Users { get; set; }
    public int ArticlesId { get; set; }
    public virtual Articles Articles { get; set; }
    public string Comment { get; set; }
    public ReviewResultStatus Status { get; set; }
    public DateTime ReviewDate { get; set; }
}
