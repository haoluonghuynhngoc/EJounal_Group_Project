namespace BussinessObject.Models;
public class Contributors
{
    public int UsersId { get; set; }
    public Users Users { get; set; }
    public int ArticlesId { get; set; }
    public Articles Articles { get; set; }
}
