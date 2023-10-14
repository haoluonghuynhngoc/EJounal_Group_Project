namespace BussinessObject.Models
{
    public class Journals
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Location { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public string Name { get; set; }
        public string SortDescription { get; set; }
        public string Status { get; set; }

        // One To Many
        public virtual ICollection<Articles> Articles { get; set; }
        // Many To One
        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }
        // Many To One
        public int UserId { get; set; }
        public virtual Users? Users { get; set; }
    }
}
