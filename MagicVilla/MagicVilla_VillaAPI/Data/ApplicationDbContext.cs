using Microsoft.EntityFrameworkCore;
using MagicVilla_VillaAPI.Models;
using System.Reflection.Emit;

namespace MagicVilla_VillaAPI.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<Villa> Villas { get; set; }
        public DbSet<VillaNumber> VillaNumbers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
                new Villa()
                {
                    Id = 1,
                    Name = "Royal villa",
                    Details = "foop  bio ajokp smopkpk dofinsion",
                    ImageUrl = "",
                    Occupancy = 4,
                    Rate = 1200,
                    Sqft = 700,
                    Amenity = "",
                    CreatedDate = DateTime.Now


                },
                     new Villa()
                     {
                         Id = 2,
                         Name = "premium villa",
                         Details = "hello bio ajokp smopkpk dofinsion",
                         ImageUrl = "",
                         Occupancy = 5,
                         Rate = 1500,
                         Sqft = 800,
                         Amenity = "",
                         CreatedDate=DateTime.Now
                     }
            );

            modelBuilder.Entity<VillaNumber>().HasData(

               
            );
        }
    }
}
