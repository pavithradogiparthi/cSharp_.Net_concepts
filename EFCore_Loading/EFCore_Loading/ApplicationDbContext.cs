using EFCore_Loading.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore_Loading
{
    public class ApplicationDbContext:DbContext
    {
             public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        public DbSet<Villa>Villas { get; set; }
        public DbSet<VillaAmenity> VillaAmenities { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
              .UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Villa>().HasData(
                new Villa
                {
                    Id = 1,
                    Name = "Royal villa",
                    Price = 20000
                },
                 new Villa
                 {
                     Id = 2,
                     Name = "Preminum pool villa",
                     Price = 30000
                 },
                  new Villa
                  {
                      Id = 3,
                      Name = "pavithra pool villa",
                      Price = 50000
                  }

                );
            modelBuilder.Entity<VillaAmenity>().HasData(
                new VillaAmenity
                {
                    Id = 1,
                    Name = "private pool",
                    VillaId=1
                   
                },
                 new VillaAmenity
                 {
                     Id = 2,
                     VillaId=1,
                     Name = "Microwave"
                    
                 },
                  new VillaAmenity
                  {
                      Id = 3,
                      VillaId=2,
                      Name = "private balcony",
               
                  },
                   new VillaAmenity
                   {
                       Id = 4,
                       VillaId = 2,
                       Name = "1 king bed and 1 sofa bed",

                   },
                     new VillaAmenity
                     {
                         Id = 5,
                         VillaId = 2,
                         Name = "1 king bed and 1 sofa bed",

                     },
                       new VillaAmenity
                       {
                           Id = 6,
                           VillaId = 3,
                           Name = "1 king bed and 1 sofa bed",

                       },
                         new VillaAmenity
                         {
                             Id = 7,
                             VillaId = 3,
                             Name = "1 king bed and 1 premimmm bed",

                         }


                );
        }
    }
}
