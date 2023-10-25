using BussinessObject.Models;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ejounal_WebApp.Pages.Authors.AuthorPages
{
    public class EditModel : PageModel
    {
        private readonly IUserRepository _userRepository;

        public EditModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [BindProperty]
        public Users Users { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = _userRepository.GetById((int)id);
            if (users == null)
            {
                return NotFound();
            }
            Users = users;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (_userRepository.GetAll().Any(u => u.Id != Users.Id && u.Email == Users.Email))
            {
                ModelState.AddModelError("Users.Email", "Email already exist");
                return Page();
            }
            var users = _userRepository.GetById(Users.Id);
            if (users != null)
            {
                users.UpdateAt = DateTime.Now;
                users.Address = Users.Address;
                users.Avatar = Users.Avatar;
                users.BirthDay = Users.BirthDay;
                users.Email = Users.Email;
                users.FirstName = Users.FirstName;
                users.Lastname = Users.Lastname;
                users.PhoneNumber = Users.PhoneNumber;
                _userRepository.Update(users);
            }
            return RedirectToPage("./Index");
        }
    }
}
