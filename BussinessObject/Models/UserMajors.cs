namespace BussinessObject.Models;
public class UserMajors
{
    public int UsersId { get; set; }
    public int MajorId { get; set; }
    public virtual Majors Majors { get; set; }
    public virtual Users User { get; set; }
}
