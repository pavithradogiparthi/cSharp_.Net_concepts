using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using ocp;

namespace ocp
{
    public interface  Idiscount
    {
        double Calculate(double amount);
    }

    public class regularcustomerdiscount : Idiscount
    {
        public double Calculate(double amount) { return amount * 0.1; }
    }
    public class VIPCustomerdiscount : Idiscount {
        public double Calculate(double amount) { return amount * 0.2; }
    }

    public class EmployeeDiscount : Idiscount {
        
            public double Calculate(double amount) { return amount * 0.3; }
        

    }


}

