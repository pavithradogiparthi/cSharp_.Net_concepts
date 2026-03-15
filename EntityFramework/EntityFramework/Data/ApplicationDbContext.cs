using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;


namespace EntityFramework.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail>OrderDetails  { get; set; }
        public DbSet<Products> Products { get; set; }
        
        protected override void  OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CustomerOrders;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
