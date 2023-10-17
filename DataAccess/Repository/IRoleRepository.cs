using BussinessObject.Models;

namespace DataAccess.Repository;
public interface IRoleRepository : IRepositoryBase<Role>
{
    public void AddAllRole(List<Role> role);
}
