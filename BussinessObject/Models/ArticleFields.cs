namespace BussinessObject.Models;
public class ArticleFields
{
    public int FieldsId { get; set; }
    public virtual Fields Fields { get; set; }
    public int ArticlesId { get; set; }
    public virtual Articles Articles { get; set; }

}
