using BussinessObject.Data;
using BussinessObject.Models;
using BussinessObject.Models.enums;

namespace DataAccess.Repository.Impl;
public class UserRepositoryImpl : RepositoryBaseImpl<Users>, IUserRepository
{
    private readonly ApplicationContext _context;

    public UserRepositoryImpl(ApplicationContext context) : base(context)
    {
        _context = context;
    }

    public bool CheckRoleAndUser(Users users, RoleName roleName)
    => _context.Roles.Any(r => r.Name == roleName && r.UsersRoles.Any(u => u.Users == users));

    public Users? FindByUsernameOrEmailAndPassword(string username, string password)
    {
        return _context.Users.FirstOrDefault(user =>
        (user.Username == username || user.Email == username) && user.Password == password);
    }

    public bool FindEmailExist(string email)
    {
        return _context.Users.Any(user => user.Email == email);
    }

    public bool FindUserNameExist(string username)
    {
        return _context.Users.Any(user => user.Username == username);
    }
}
