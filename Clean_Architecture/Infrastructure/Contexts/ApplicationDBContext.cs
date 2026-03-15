using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts
{
   public  class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options) { 
         
        }
        public DbSet<Property> Properties =>Set<Property>();
        public DbSet<Image> Images =>Set<Image>();
    }
}
