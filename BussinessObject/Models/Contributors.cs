namespace BussinessObject.Models;
public class Contributors
{
    public int UsersId { get; set; }
    public virtual Users? Users { get; set; }
    public int ArticlesId { get; set; }
    public virtual Articles? Articles { get; set; }
}
