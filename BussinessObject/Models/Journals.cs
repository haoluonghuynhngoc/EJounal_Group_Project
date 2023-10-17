using BussinessObject.Models.enums;

namespace BussinessObject.Models
{
    public class Journals
    {
        public int Id { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public string Name { get; set; }
        public string SortDescription { get; set; }
        public JournalStatus Status { get; set; }
        // One To Many With Article
        public virtual ICollection<Articles> Articles { get; set; }
    }
}
