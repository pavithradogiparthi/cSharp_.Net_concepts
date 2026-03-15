using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nservicebus_example
{
  public  class Command:ICommand
    {
        public string Message { get; set; }
        
    }
    public class CommandHandler : IHandleMessages<Command>
    {
        public Task Handle(Command message, IMessageHandlerContext context)
        {
            Console.WriteLine($"Received command: {message.Message}");
            return Task.CompletedTask;
        }
    }

}
