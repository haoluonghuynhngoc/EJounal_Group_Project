namespace BussinessObject.Models
{
    public class Articles
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public string Description { get; set; }
        public string SortDescription { get; set; }
        public string Title { get; set; }
        // One To Many
        public virtual ICollection<Review> Reviews { get; set; }
        // One To Many
        public virtual ICollection<ArticlesRating> ArticlesRatings { get; set; }
        public int JournalsId { get; set; }
        public virtual Journals? Journals { get; set; }
    }
}
