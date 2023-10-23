using BussinessObject.AccountView;
using BussinessObject.Models.enums;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ejounal_WebApp.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IUserRepository _userRepository;

        public LoginModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [BindProperty]
        public LoginAV LoginAV { get; set; }
        public void OnGet()
        {
            //if (HttpContext.Session.GetString(Constrains.SessionAttribute.AUTH_USER_NAME) == null)
            //{
            //    return Page();
            //}
            //else
            //{
            //    return RedirectToPage("./Index");
            //}
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var account = _userRepository.FindByUsernameOrEmailAndPassword(LoginAV.UserName, LoginAV.Password);
            if (account == null)
            {
                ModelState.AddModelError("LoginAV.UserName", "Username or password not correct");
            }
            else if (account.Status == UserStatus.INACTIVE)
            {
                ModelState.AddModelError("LoginAV.UserName", "Your account has been banned");
            }
            else
            {
                foreach (var x in account.UsersRoles)
                {

                    Console.WriteLine(x.Role.Name == RoleName.ADMIN);
                }
            }
            //else if (account.UsersRoles. != "ADMIN")
            //{
            //    ModelState.AddModelError("LoginAV.UserName", "Your account does not have permission to login");
            //}
            //else
            //{
            //    HttpContext.Session.SetString(Constrains.SessionAttribute.AUTH_USER_ROLE, account.Role);
            //    HttpContext.Session.SetString("accountId", account.AccountId.ToString());
            //    HttpContext.Session.SetInt32("accountIdInt", account.AccountId);
            //    HttpContext.Session.SetString(Constrains.SessionAttribute.AUTH_USER_NAME, account.Username);
            //    HttpContext.Session.SetString(Constrains.SessionAttribute.AUTH_USER_FIRST_NAME, account.FirstName);
            //}
            if (ModelState.IsValid)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                return Page();
            }

        }
    }
}
