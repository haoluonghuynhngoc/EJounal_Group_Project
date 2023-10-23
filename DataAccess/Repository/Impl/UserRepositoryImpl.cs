using BussinessObject.Data;
using BussinessObject.Models;

namespace DataAccess.Repository.Impl;
public class UserRepositoryImpl : RepositoryBaseImpl<Users>, IUserRepository
{
    private readonly ApplicationContext _context;

    public UserRepositoryImpl(ApplicationContext context) : base(context)
    {
        _context = context;
    }

    public Users? FindByUsernameOrEmailAndPassword(string username, string password)
    {
        return _context.Users.FirstOrDefault(user =>
        (user.Username == username || user.Email == username) && user.Password == password);
    }
}
