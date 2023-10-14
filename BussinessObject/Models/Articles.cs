namespace BussinessObject.Models
{
    public class Articles
    {
        public int Id { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string SortDescription { get; set; }
        public string Title { get; set; }
        // Many To Many With User
        public virtual ICollection<ReviewResult> ReviewResults { get; set; }
        // Many To Many With Fields
        public virtual ICollection<ArticleFields> ArticleFields { get; set; }
        // Many To One With Jounal
        public int JournalsId { get; set; }
        public virtual Journals? Journals { get; set; }
        // Many To Many With User
        public virtual ICollection<Contributors> Contributors { get; set; }
    }
}
