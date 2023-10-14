using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // Many To Many
        public virtual ICollection<UsersRole> UsersRoles { get; set; }
    }
}
