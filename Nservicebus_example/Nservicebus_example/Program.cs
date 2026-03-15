using NServiceBus.Routing;
using NServiceBus;
using Nservicebus_example;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder=Host.CreateApplicationBuilder();
var endpointconfiguration = new EndpointConfiguration("MyEndpoint");
var transport=endpointconfiguration.UseTransport<LearningTransport>();
transport.StorageDirectory("C:\\Users\\pavithra dogiparthi\\Desktop\\internship\\Interns-BE\\pavithra_dogiparthi\\c#_Practice\\Nservicebus_example\\Nservicebus_example\\pathfile.txt");
//endpointconfiguration.UsePersistence<LearningPersistence>();
endpointconfiguration.UseSerialization<NewtonsoftJsonSerializer>();
var routing = transport.Routing();
routing.RouteToEndpoint(typeof(Command), "ReceiverEndpoint");
builder.UseNServiceBus(endpointconfiguration);
var host=builder.Build();

//var host = Host.CreateDefaultBuilder(args).
//    ConfigureServices((context, services) =>
//    {
//        services.AddSingleton<IHandleMessages<Command>, MyCommandHandler>();
//        ;
//    }).Build();

var endpointinstance =await Endpoint.Start(endpointconfiguration).ConfigureAwait(false);
await endpointinstance.SendLocal(new Command { Message="helllllllllllllllll"});

//for (var i = 0; i < 10; i++)
//await endpointinstance.Publish(new Event { EventName = "MyFirstEvent" });



Console.WriteLine("Nservicebus endpoint is running.press enter to exit");
//Console.ReadLine();
// Stop the endpoint
await endpointinstance.Stop()
    .ConfigureAwait(false);


