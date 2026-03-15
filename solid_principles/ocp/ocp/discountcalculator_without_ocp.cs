using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ocp
{
    internal class discountcalculator_without_ocp
    {
        public double CalculateDiscount(Customertype customertype, double amount)
        {
            switch (customertype)
            {
                case Customertype.Regular:
                    return amount*0.1;
                case Customertype.VIP:
                    return amount*0.2;
                case Customertype.employee:
                    return amount*0.3;
                default:
                    return 0;


            }
        }
    }
}
