using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dependency_injection
{
    internal class PaymentWithMethodDI
    {

        public void Makepay(Ipayment payment)
        {
            if(payment ==null)
            {
                throw new ArgumentNullException("game cannot be empty");
            }
            payment.pay();
        }
    }
}
