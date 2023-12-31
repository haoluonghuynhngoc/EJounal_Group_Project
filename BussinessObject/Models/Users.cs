﻿using BussinessObject.Models.enums;
using System.ComponentModel.DataAnnotations;

namespace BussinessObject.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Address { get; set; }
        public string Avatar { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public DateTime BirthDay { get; set; }
        public UserStatus Status { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Email is not in a valid format.")]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string? Password { get; set; }
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Telephone must be a 10-digit number.")]
        public string PhoneNumber { get; set; }
        // Many To Many With Role
        public virtual ICollection<UsersRole>? UsersRoles { get; set; }
        // Many To Many With Major
        public virtual ICollection<UserMajors>? UserMajors { get; set; }
        // Many To Many With Article
        public virtual ICollection<ReviewResult>? ReviewResults { get; set; }
        // Many To Many With Article
        public virtual ICollection<Contributors>? Contributors { get; set; }
    }
}
