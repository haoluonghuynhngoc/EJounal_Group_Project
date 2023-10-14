namespace BussinessObject.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // Many To Many With User
        public virtual ICollection<UsersRole> UsersRoles { get; set; }
    }
}
