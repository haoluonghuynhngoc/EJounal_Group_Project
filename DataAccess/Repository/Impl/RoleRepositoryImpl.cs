using BussinessObject.Data;
using BussinessObject.Models;

namespace DataAccess.Repository.Impl;
public class RoleRepositoryImpl : RepositoryBaseImpl<Role>, IRoleRepository
{
    private readonly ApplicationContext _context;

    public RoleRepositoryImpl(ApplicationContext context) : base(context)
    {
        _context = context;
    }

    public void AddAllRole(List<Role> role)
    {
        _context.AddRange(role);
        _context.SaveChanges();
    }
}
