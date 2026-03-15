using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dependency_injection
{
    internal class PaymentWithConstructorDI
    {
        private readonly Ipayment _payment;
       
        public PaymentWithConstructorDI(Ipayment payment)
        {
            if(payment ==null)
            {
                throw new ArgumentNullException("payment cannot be empty");
            }
            _payment = payment;
        }
        public void makepayment()
        {
            _payment.pay();
        }
    }
}
