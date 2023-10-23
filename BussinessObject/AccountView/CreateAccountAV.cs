﻿using System.ComponentModel.DataAnnotations;

namespace BussinessObject.AccountView;
public class CreateAccountAV
{
    [Display(Name = "Username")]
    [DataType(DataType.Text)]
    [Required(ErrorMessage = "Username can not be empty!")]
    public string Username { get; set; }
    [Required(ErrorMessage = "Password can not be empty")]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Display(Name = "Email")]
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "Email can not be empty!")]
    public string Email { get; set; }

    [Display(Name = "First Name")]
    [DataType(DataType.Text)]
    [Required(ErrorMessage = "First name can not be empty!")]
    public string FirstName { get; set; }

    [Display(Name = "Last Name")]
    [DataType(DataType.Text)]
    public string LastName { get; set; }
}
