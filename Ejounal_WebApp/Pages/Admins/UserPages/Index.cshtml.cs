using BussinessObject.Models;
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
            Users = _userRepository.GetAll().ToList();
        }
    }
}
