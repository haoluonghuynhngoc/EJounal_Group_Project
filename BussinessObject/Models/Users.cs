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
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        // many to many
        public virtual ICollection<UsersRole> UsersRoles { get; set; }
        public virtual ICollection<Journals> Journals { get; set; }
        public virtual ICollection<ArticlesRating> ArticlesRatings { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
