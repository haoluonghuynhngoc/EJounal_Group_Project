namespace BussinessObject.Models;
public class ReviewFields
{
    public int UsersId { get; set; }
    public virtual Users Users { get; set; }
    public int FieldsId { get; set; }
    public virtual Fields Fields { get; set; }
}
