namespace BussinessObject.Models;
public class UserMajors
{
    public int UsersId { get; set; }
    public int MajorsId { get; set; }
    public virtual Majors? Majors { get; set; }
    public virtual Users? User { get; set; }
}
