using EventsPractice;

namespace EventSubscriber
{
    internal class Program
    {
        static async  Task  Main(string[] args)
        {
            var endpointConfiguration = new EndpointConfiguration("BillingService");
            endpointConfiguration.UseSerialization<NewtonsoftJsonSerializer>();
            var transport = endpointConfiguration.UseTransport<LearningTransport>();
            transport.StorageDirectory("C:\\Users\\pavithra dogiparthi\\Desktop\\EventsPractice\\EventsPractice");

            var routing = transport.Routing();
            //routing.RegisterPublisher(typeof(OrderPlaced), "OrderService");
            routing.RouteToEndpoint(typeof(OrderPlaced), "OrderService");

            var endpointInstance = await Endpoint.Start(endpointConfiguration);

            Console.WriteLine("BillingService is running...");
            Console.ReadLine();
            await endpointInstance.Stop();
        }
    }
}
