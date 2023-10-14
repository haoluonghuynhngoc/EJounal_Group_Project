namespace BussinessObject.Models;
public class Majors
{
    public int Id { get; set; }
    public string Name { get; set; }
    // Many To Many With User
    public virtual ICollection<UserMajors> UserMajors { get; set; }
}
