using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dependency_injection
{
    internal class PaymentWithoutDI
    {
        private readonly Ipayment _payment;
        public PaymentWithoutDI()
        {
            _payment = new UPI();
        }
        public void makepaymentwithoutDI()
        {
            _payment.pay();
        }

    }
}
