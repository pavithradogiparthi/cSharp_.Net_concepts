using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP
{
   public interface orderprocessor
    {
        void processonlineorder();
        void processinstorepickuporder();
        void applydiscount();
        void shiporder();
    }
    public class onlineorderprocessor : orderprocessor {

        public void processonlineorder()
        {
            Console.WriteLine("processing online order");
        }
        public void processinstorepickuporder()
        {
            throw new NotSupportedException("not supported in online orders");
        }
        public void applydiscount()
        {
            Console.WriteLine("applying discount to online orders");
        }
        public void shiporder()
        {
            Console.WriteLine("ship order in online orders");
        }

    }
    public class instoreorderprocessor : orderprocessor {

        public void processonlineorder()
        {
            throw new NotSupportedException("not suppoted in instoreorders");
        }
        public void processinstorepickuporder()
        {
            Console.WriteLine("processing instore pickup orders");
        }
        public void applydiscount()
        {
            Console.WriteLine("applying discount to online orders");
        }
        public void shiporder()
        {
            throw new NotSupportedException("not supported in instore orders");
        }

    }


}
