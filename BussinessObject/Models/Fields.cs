namespace BussinessObject.Models;
public class Fields
{
    public int Id { get; set; }
    public string Name { get; set; }
    // Many To Many With Article
    public virtual ICollection<ArticleFields> ArticleFields { get; set; }
    // Many To Many With User
    public virtual ICollection<ReviewFields> ReviewFields { get; set; }
}
