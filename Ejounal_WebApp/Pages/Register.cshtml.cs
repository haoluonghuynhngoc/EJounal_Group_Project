using BussinessObject.AccountView;
using BussinessObject.Models;
using BussinessObject.Models.enums;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ejounal_WebApp.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public RegisterModel(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        [BindProperty]
        public RegisterAV RegisterAV { get; set; }

        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (RegisterAV.Password != RegisterAV.ConfirmPassword)
            {
                ModelState.AddModelError("RegisterAV.ConfirmPassword", "Confirm does not match");
            }
            if (_userRepository.FindEmailExist(RegisterAV.Email))
            {
                ModelState.AddModelError("RegisterAV.Email", "Email already exist");
            }
            if (_userRepository.FindUserNameExist(RegisterAV.Username))
            {
                ModelState.AddModelError("RegisterAV.Username", "Username already exist");
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Role role = _roleRepository.GetAll().FirstOrDefault(r => r.Name.Equals(RoleName.REVIEWER));
            if (role != null)
            {
                _userRepository.Add(new Users()
                {
                    Username = RegisterAV.Username,
                    Address = "Tp Ho Chi Minh",
                    Avatar = "",
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                    // BirthDay = new DateTime(2009, 09, 09),
                    BirthDay = DateTime.Now,
                    Status = UserStatus.ACTIVE,
                    Email = RegisterAV.Email,
                    FirstName = RegisterAV.FirstName,
                    Lastname = RegisterAV.LastName,
                    Password = RegisterAV.Password,
                    PhoneNumber = "",
                    UsersRoles = new List<UsersRole> { new UsersRole { Role = role } }
                });
            }
            return RedirectToPage("./Login");
        }
    }
}
