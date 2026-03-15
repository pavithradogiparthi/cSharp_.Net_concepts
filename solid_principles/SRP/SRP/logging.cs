using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP
{
    internal class logging
    {
        public void LogError(string message) => Console.WriteLine("Error: " + message);
        public void LogInfo(string message) => Console.WriteLine("Info: " + message);
    }
}
