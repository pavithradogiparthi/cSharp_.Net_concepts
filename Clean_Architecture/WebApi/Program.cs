using Application;
using Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApi.MiddleWare;
using WebApi;

   var builder = WebApplication.CreateBuilder(args);

       
        // Add services to the container.
        builder.Services.AddApplicationLayerServices();
        builder.Services.AddInfraStructureServices(builder.Configuration);
var cachesettings = builder.Services.GetCacheSettings(builder.Configuration);
//configure redis
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = cachesettings.DestinationUrl;
});
builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(opt=>opt.DisplayRequestDuration());
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.UseMiddleware<ErrorHandlingMiddleware>();

        app.MapControllers();

        app.Run();
    