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
}
