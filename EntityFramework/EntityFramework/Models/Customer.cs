using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public int Name { get; set; }
        public string FirstName { get; set; } = null;
        public string LastName { get; set; } = null;
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public ICollection<Order> Orders { get; set; } = null;

    }
}
