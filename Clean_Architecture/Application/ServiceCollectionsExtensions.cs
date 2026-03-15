using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using FluentValidation;

using Application.PipelineBehaviours;


namespace Application
{
    public static class ServiceCollectionsExtensions
    {
        public static void AddApplicationLayerServices( this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly())
                      .AddMediatR(Assembly.GetExecutingAssembly())
                      .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly())
                      .AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingPipelineBehaviour<,>))

                      .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehaviour<,>)).
                      AddTransient(typeof(IPipelineBehavior<,>), typeof(CacheRemovalPipelineBehaviour<,>))
                      .AddTransient(typeof(IPipelineBehavior<,>), typeof(CachePipelineBehaviour<,>));
                      
         }
    }
}
