namespace BussinessObject.Models;
public class UserMajors
{
    public int UsersId { get; set; }
    public int MajorId { get; set; }
    public Majors Majors { get; set; }
    public Users User { get; set; }
}
