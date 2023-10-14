using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // One To Many
        public virtual ICollection<Journals> Journals { get; set; }
    }
}
