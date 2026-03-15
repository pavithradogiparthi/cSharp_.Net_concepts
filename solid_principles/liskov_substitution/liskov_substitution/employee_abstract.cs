using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace liskov_substitution
{
   public abstract class employee_abstract
    {

        protected string Name;
        protected employee_abstract(string name)
        {
            Name = name;
        }
        public abstract decimal calculateMonthpayment();
    }

   class fte : employee_abstract
    {
        private decimal Monthlysalary;
        public fte( string name,decimal monthlysalary):base(name)
        {
            Monthlysalary = monthlysalary;
        }
        public override decimal calculateMonthpayment()
        {
            return Monthlysalary;
        }
    }
    class intern :employee_abstract
    {
        private decimal Hourlyrate;
        private int Hoursworked;
        public intern(string name,decimal hourlyrate,int hoursworked):base(name)
        {
            Hourlyrate = hourlyrate;
            Hoursworked = hoursworked;
        }
        public override decimal calculateMonthpayment()
        {
            return Hoursworked * Hourlyrate;
        }
    }
}
