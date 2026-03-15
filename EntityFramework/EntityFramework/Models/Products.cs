using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Models
{
    public class Products
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null;

        [Column(TypeName ="decimal(6,2)")]
        public decimal Price { get; set; }

 

    }
}
