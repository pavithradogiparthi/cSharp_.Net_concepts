
using NServiceBus;

namespace EventsPractice
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            var endpointConfiguration = new EndpointConfiguration("OrderService");
            endpointConfiguration.UseSerialization<NewtonsoftJsonSerializer>();

            var transport = endpointConfiguration.UseTransport<LearningTransport>();
            transport.StorageDirectory("C:\\Users\\pavithra dogiparthi\\Desktop\\EventsPractice\\EventsPractice");
          

            var endpointInstance = await Endpoint.Start(endpointConfiguration);

            Console.WriteLine("Publishing OrderPlaced event...");

            await endpointInstance.Publish(new OrderPlaced
            {
                OrderId = Guid.NewGuid(),
                CustomerName = "pavithra"
            });

            Console.WriteLine("Event Published!");
            Console.ReadLine();
            await endpointInstance.Stop();
        }
    }
}
