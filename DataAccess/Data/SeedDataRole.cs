using BussinessObject.Models;
using BussinessObject.Models.enums;
using DataAccess.Repository;

namespace DataAccess.Data;
public class SeedDataRole
{
    private readonly IRoleRepository _roleRepository;

    public SeedDataRole(IRoleRepository roleRepository)
    {
        this._roleRepository = roleRepository;
    }

    public void Initialize()
    {
        if (_roleRepository.GetAll().Any())
        {
            return;
        }
        _roleRepository.AddAllRole(new List<Role> { new Role { Name = RoleName.ADMIN }
                                                 , new Role { Name = RoleName.GUEST }
                                                 , new Role { Name = RoleName.AUTHOR }
                                                 , new Role { Name = RoleName.REVIEWER }
                                                 }
        );
    }
}
