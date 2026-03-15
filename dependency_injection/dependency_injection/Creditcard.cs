using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dependency_injection
{
    internal class Creditcard:Ipayment
    {
        public void pay()
        {
            Console.WriteLine("paying through Creditcard using DI");
        }
    }
}
