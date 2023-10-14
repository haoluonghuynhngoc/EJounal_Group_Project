namespace BussinessObject.Models
{
    public class UsersRole
    {
        public int UsersId { get; set; }
        public int RoleId { get; set; }

        public virtual Users? Users { get; set; }

        public virtual Role? Role { get; set; }
    }
}
