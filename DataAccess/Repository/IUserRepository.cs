using BussinessObject.Models;
using BussinessObject.Models.enums;

namespace DataAccess.Repository;
public interface IUserRepository : IRepositoryBase<Users>
{
    Users? FindByUsernameOrEmailAndPassword(string username, string password);
    bool FindEmailExist(string email);
    bool FindUserNameExist(string username);
    bool CheckRoleAndUser(Users users, RoleName roleName);
}
