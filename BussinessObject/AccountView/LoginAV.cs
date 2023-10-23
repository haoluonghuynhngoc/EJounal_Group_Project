using System.ComponentModel.DataAnnotations;

namespace BussinessObject.AccountView;
public class LoginAV
{
    [Display(Name = "Username or Email")]
    [DataType(DataType.Text)]
    [Required(ErrorMessage = "Username or email can not be empty!")]
    public string UserName { get; set; }
    [Required(ErrorMessage = "Password can not be empty")]
    [MinLength(1, ErrorMessage = "Password must be at least 1 characters")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}
