namespace BussinessObject.Models;
public class ReviewFields
{
    public int UsersId { get; set; }
    public Users Users { get; set; }
    public int FieldsId { get; set; }
    public Fields Fields { get; set; }
}
