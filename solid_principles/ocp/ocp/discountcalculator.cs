using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ocp
{
    internal class discountcalculator
    {
        private readonly Idiscount _idiscount;
        public discountcalculator(Idiscount idiscount)
        {
            _idiscount = idiscount;
        }
        public double calculatediscount(double amount)
        {
            return _idiscount.Calculate(amount);
        }


    }
}
