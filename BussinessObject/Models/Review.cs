namespace BussinessObject.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public DateTime ReviewData { get; set; }
        public int ArticlesId { get; set; }
        public virtual Articles? Articles { get; set; }
        // many To one With User
        public int UsersId { get; set; }
        public virtual Users? Users { get; set; }

    }
}
