using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;

namespace Nservicebus_example
{
    public class Event : IEvent
    {
        public string EventName { get; set; }
    }
    public class MyEventHandler : IHandleMessages<Event>
    {
        public Task Handle(Event message, IMessageHandlerContext context)
        {
            Console.WriteLine($"Event received: {message.EventName}");
            return Task.CompletedTask;
        }
    }
}
