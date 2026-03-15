using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventsPractice;

namespace EventSubscriber
{
 public  class OrderPlacedHandler:IHandleMessages<OrderPlaced>
    {
        public async Task Handle(OrderPlaced message, IMessageHandlerContext context)
        {
            Console.WriteLine($"Processing payment for Order {message.OrderId}...");
            await Task.Delay(2000); // Simulating payment processing
            Console.WriteLine($"Payment completed for {message.CustomerName}!");
        }
    }
}
