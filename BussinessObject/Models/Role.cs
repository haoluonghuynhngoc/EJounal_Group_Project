using BussinessObject.Models.enums;

namespace BussinessObject.Models
{
    public class Role
    {
        public int Id { get; set; }
        public RoleName Name { get; set; }
        // Many To Many With User
        public virtual ICollection<UsersRole> UsersRoles { get; set; }
    }
}
