using BussinessObject.Models;
using BussinessObject.Models.enums;
using DataAccess.Repository;
using Ejounal_WebApp.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ejounal_WebApp.Pages
{
    public class RegisterAuthorModel : PageModel
    {
        const string KEY_SESSION_REVIEWER = "REVIEWER";
        const string KEY_SESSION_AUTHOR = "AUTHOR";
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public RegisterAuthorModel(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public Users Users { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync()
        {
            var sessionReviewer = (SessionAuthor)HttpContext.Session.Get<SessionAuthor>(KEY_SESSION_REVIEWER);
            if (sessionReviewer != null)
            {
                var users = _userRepository.GetById(sessionReviewer.UserId);
                if (users == null)
                {
                    return NotFound();
                }
                else
                {
                    Users = users;
                }
            }
            var sessionAuthor = (SessionAuthor)HttpContext.Session.Get<SessionAuthor>(KEY_SESSION_AUTHOR);
            if (sessionAuthor != null)
            {
                var usersAuthor = _userRepository.GetById(sessionAuthor.UserId);
                if (usersAuthor == null)
                {
                    return NotFound();
                }
                else
                {
                    Users = usersAuthor;
                }
            }
            return Page();
        }

        public IActionResult OnPost(string confirm)
        {
            if (confirm == "yes")
            {
                var sessionReview = HttpContext.Session.Get<SessionAuthor>(KEY_SESSION_REVIEWER);
                var sessionAuthor = HttpContext.Session.Get<SessionAuthor>(KEY_SESSION_AUTHOR);

                if (sessionReview != null)
                {
                    var usersReview = _userRepository.GetById(sessionReview.UserId);
                    if (usersReview != null)
                    {
                        Users = usersReview;
                        if (!_userRepository.CheckRoleAndUser(usersReview, RoleName.AUTHOR))
                        {
                            Role role = _roleRepository.GetAll().FirstOrDefault(r => r.Name.Equals(RoleName.AUTHOR));
                            if (role != null)
                            {
                                usersReview.UsersRoles.Add(new UsersRole { Role = role });
                                _userRepository.Update(usersReview);
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("Error", "You have already register Author");
                            return Page();
                        }

                    }
                }
                else if (sessionAuthor != null)
                {
                    var usersAuthor = _userRepository.GetById(sessionAuthor.UserId);
                    if (usersAuthor != null)
                    {
                        Users = usersAuthor;
                        if (!_userRepository.CheckRoleAndUser(usersAuthor, RoleName.AUTHOR))
                        {
                            Role role = _roleRepository.GetAll().FirstOrDefault(r => r.Name.Equals(RoleName.AUTHOR));
                            if (role != null)
                            {
                                usersAuthor.UsersRoles.Add(new UsersRole { Role = role });
                                _userRepository.Update(usersAuthor);
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("Error", "You have already register Author");
                            return Page();
                        }
                    }

                }

            }
            return RedirectToPage("./Reviewers/ArticlesReviewer/Index");
        }
    }
}
