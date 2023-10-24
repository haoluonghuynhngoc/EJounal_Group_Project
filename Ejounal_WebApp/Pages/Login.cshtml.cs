using BussinessObject.AccountView;
using BussinessObject.Models.enums;
using DataAccess.Repository;
using Ejounal_WebApp.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ejounal_WebApp.Pages
{
    public class LoginModel : PageModel
    {
        const string KEY_SESSION_ADMIN = "ADMIN";
        const string KEY_SESSION_AUTHOR = "AUTHOR";
        const string KEY_SESSION_REVIEWER = "REVIEWER";
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
                return Page();
            }
            else if (account.Status == UserStatus.INACTIVE)
            {
                ModelState.AddModelError("LoginAV.UserName", "Your account has been banned");
                return Page();
            }
            else
            {

                if (_userRepository.CheckRoleAndUser(account, RoleName.ADMIN))
                {
                    var adminAccount = account.UsersRoles.FirstOrDefault(z => z.Role.Name == RoleName.ADMIN);
                    if (adminAccount != null)
                    {
                        RemoveSession(KEY_SESSION_REVIEWER);
                        RemoveSession(KEY_SESSION_AUTHOR);
                        //HttpContext.Session.SetO
                        HttpContext.Session.Set<SessionAuthor>(KEY_SESSION_ADMIN, new SessionAuthor()
                        {
                            UserId = adminAccount.UsersId,
                            UserName = adminAccount.Users.Username,
                            RoleName = RoleName.ADMIN
                        });
                    }
                }
                else if (_userRepository.CheckRoleAndUser(account, RoleName.AUTHOR))
                {
                    var authorAccount = account.UsersRoles.FirstOrDefault(z => z.Role.Name == RoleName.AUTHOR);
                    if (authorAccount != null)
                    {
                        RemoveSession(KEY_SESSION_REVIEWER);
                        RemoveSession(KEY_SESSION_ADMIN);
                        HttpContext.Session.Set<SessionAuthor>(KEY_SESSION_AUTHOR, new SessionAuthor()
                        {
                            UserId = authorAccount.UsersId,
                            UserName = authorAccount.Users.Username,
                            RoleName = RoleName.AUTHOR
                        });
                    }
                }
                else if (_userRepository.CheckRoleAndUser(account, RoleName.REVIEWER))
                {
                    var reviewerAccount = account.UsersRoles.FirstOrDefault(z => z.Role.Name == RoleName.REVIEWER);
                    if (reviewerAccount != null)
                    {
                        RemoveSession(KEY_SESSION_ADMIN);
                        RemoveSession(KEY_SESSION_AUTHOR);
                        HttpContext.Session.Set<SessionAuthor>(KEY_SESSION_REVIEWER, new SessionAuthor()
                        {
                            UserId = reviewerAccount.UsersId,
                            UserName = reviewerAccount.Users.Username,
                            RoleName = RoleName.REVIEWER
                        });
                    }
                }
            }
            if (ModelState.IsValid)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                return Page();
            }

        }
        public void RemoveSession(string sessionKey)
        {
            if (HttpContext.Session.TryGetValue(sessionKey, out _))
            {
                HttpContext.Session.Remove(sessionKey);
            }
        }
    }

}
