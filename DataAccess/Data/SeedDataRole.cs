using BussinessObject.Models;
using BussinessObject.Models.enums;
using DataAccess.Repository;

namespace DataAccess.Data;
public class SeedDataRole
{
    private readonly IRoleRepository roleRepository;

    public SeedDataRole(IRoleRepository roleRepository)
    {
        this.roleRepository = roleRepository;
    }

    public void Initialize()
    {
        if (roleRepository.GetAll().Any())
        {
            return;
        }
        roleRepository.AddAllRole(new List<Role> { new Role { Name = RoleName.ADMIN }
                                                 , new Role { Name = RoleName.GUEST }
                                                 , new Role { Name = RoleName.AUTHOR }
                                                 , new Role { Name = RoleName.REVIEWER }
                                                 }
        );
    }
}
