using BussinessObject.Models;
using BussinessObject.Models.enums;
using DataAccess.Repository;

namespace DataAccess.Data;
public class SeedDataAdmin
{
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;

    public SeedDataAdmin(IUserRepository userRepository, IRoleRepository roleRepository)
    {
        _userRepository = userRepository;
        _roleRepository = roleRepository;
    }
    public void Initialize()
    {
        if (_userRepository.GetAll().Any())
        {
            return;
        }
        Role role = _roleRepository.GetAll().FirstOrDefault(r => r.Name.Equals(RoleName.ADMIN));
        if (role != null)
        {
            _userRepository.Add(new Users()
            {
                Username = "Admin",
                Address = "Tp Ho Chi Minh",
                Avatar = "",
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now,
                BirthDay = new DateTime(2009, 09, 09),
                Status = UserStatus.ACTIVE,
                Email = "Haoluong@gmail.com",
                FirstName = "A",
                Lastname = "Nguyen Van",
                Password = "1",
                PhoneNumber = "1232323232",
                UsersRoles = new List<UsersRole> { new UsersRole { Role = role } }
            });
        }

    }
}
