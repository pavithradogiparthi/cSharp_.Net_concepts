using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace liskov_substitution
{
     public  class Employee {
        protected string Name;
        public Employee(string name)
        {
            Name = name;
        }
        public virtual decimal calculatesalary()
        {
            return 3000;
        }
    
    }
   public  class fulltimeemployee : Employee
    {
        public fulltimeemployee(string name) : base(name) { }
        public override decimal calculatesalary()
        {
            
                return 4000;

        }
    }
    class Intern : Employee {
        public decimal HourlyRate;
        public int Hoursworked;
        public Intern(string name, decimal hourlyrate, int hoursworked) : base(name)
        {
            HourlyRate = hourlyrate;
            Hoursworked = hoursworked;

        }
        public override decimal calculatesalary()
        {
            
            throw new NotImplementedException("intern not implement!!!!!");
        }


    }



}



