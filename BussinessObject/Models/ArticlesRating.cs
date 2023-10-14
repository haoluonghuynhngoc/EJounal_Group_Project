namespace BussinessObject.Models
{
    public class ArticlesRating
    {
        public int Id { get; set; }
        public int RatingScore { get; set; }
        public int ArticlesId { get; set; }
        public virtual Articles? Articles { get; set; }
        // Many to One With user
        public int UsersId { get; set; }
        public virtual Users? Users { get; set; }
    }
}
