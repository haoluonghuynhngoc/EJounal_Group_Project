using BussinessObject.Models;
using BussinessObject.Models.enums;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ejounal_WebApp.Pages.Admins.UserPages
{
    public class IndexModel : PageModel
    {
        private readonly IUserRepository _userRepository;

        public IndexModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IList<Users> Users { get; set; } = default!;

        public async Task OnGetAsync()
        {
            // Users = _userRepository.GetAll().ToList();
            Users = _userRepository.GetAll().ToList()
                .Where(u => u.UsersRoles.Any(a => a.Role.Name != RoleName.ADMIN)).ToList();
        }
    }
}
