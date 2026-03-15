using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dependency_injection
{
    internal class PaymentWithPropertiesDI
    {
        public Ipayment Pay { get; set; }
        public void Makepayment()
        {
            Pay.pay();
        }
    }
}
