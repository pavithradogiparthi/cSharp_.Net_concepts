// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using Servicelifetimes;

var serviceprovider = new ServiceCollection()
    .AddTransient<TransientServiceLifetime>().
    AddScoped<ScopedServiceLifetime>().
    AddSingleton<SingletonServiceLifetime>().
    AddTransient<scopedandsingletonintransient>()
    .AddSingleton<transientandscopedinsidesingleton>()
    .BuildServiceProvider();
Console.WriteLine("===request1==");
Console.WriteLine(serviceprovider.GetService<TransientServiceLifetime>());
Console.WriteLine(serviceprovider.GetService<ScopedServiceLifetime>());
Console.WriteLine(serviceprovider.GetService<SingletonServiceLifetime>());



Console.WriteLine("===request2==");
Console.WriteLine(serviceprovider.GetService<TransientServiceLifetime>());
Console.WriteLine(serviceprovider.GetService<ScopedServiceLifetime>());
Console.WriteLine(serviceprovider.GetService<SingletonServiceLifetime>());

var temp = serviceprovider.CreateScope();
Console.WriteLine("===request3==");
Console.WriteLine(temp.ServiceProvider.GetService<TransientServiceLifetime>());
Console.WriteLine(temp.ServiceProvider.GetService<ScopedServiceLifetime>());
Console.WriteLine(temp.ServiceProvider.GetService<SingletonServiceLifetime>());

using (var scope = serviceprovider.CreateScope())
{
    Console.WriteLine("===request4==");
    Console.WriteLine(scope.ServiceProvider.GetService<TransientServiceLifetime>());
    Console.WriteLine(scope.ServiceProvider.GetService<ScopedServiceLifetime>());
    Console.WriteLine(scope.ServiceProvider.GetService<SingletonServiceLifetime>());

}

Console.WriteLine("===request5==");
Console.WriteLine(temp.ServiceProvider.GetService<TransientServiceLifetime>());
Console.WriteLine(temp.ServiceProvider.GetService<ScopedServiceLifetime>());
Console.WriteLine(temp.ServiceProvider.GetService<SingletonServiceLifetime>());

//using (var scope = serviceprovider.CreateScope())
//{
//    Console.WriteLine("===request3==");
//    Console.WriteLine(scope.ServiceProvider.GetService<TransientServiceLifetime>());
//    Console.WriteLine(scope.ServiceProvider.GetService<ScopedServiceLifetime>());
//    Console.WriteLine(scope.ServiceProvider.GetService<SingletonServiceLifetime>());


//}
tempclass.tempfun(serviceprovider);
tempclass.tempfun(serviceprovider);

Console.WriteLine("===last ==");
Console.WriteLine(serviceprovider.GetService<scopedandsingletonintransient>());
Console.WriteLine(serviceprovider.GetService<transientandscopedinsidesingleton>());
Console.WriteLine(serviceprovider.GetService<transientandscopedinsidesingleton>());







