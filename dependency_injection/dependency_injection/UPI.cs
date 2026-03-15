using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dependency_injection
{
    internal class UPI:Ipayment
    {
       public  void pay()
        {
            Console.WriteLine("paying through UPI using DI");
        }
    }
}
