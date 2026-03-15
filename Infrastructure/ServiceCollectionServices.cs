using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repository;
using Infrastructure.Contexts;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
   public static class ServiceCollectionServices
    {
        public static IServiceCollection AddInfraStructureServices(this IServiceCollection services, IConfiguration configuration) {
            return services
                .AddTransient<IPropertyRepo, PropertyRepo>()
                .AddTransient<IImageRepo,ImageRepo>()
                .AddDbContext<ApplicationDBContext>(options => options
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection"))); }
    }
}
