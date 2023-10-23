using BussinessObject.Models;

namespace DataAccess.Repository;
public interface IUserRepository : IRepositoryBase<Users>
{
    Users? FindByUsernameOrEmailAndPassword(string username, string password);
}
