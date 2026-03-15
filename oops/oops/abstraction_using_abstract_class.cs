using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oops
{//abstraction is hiding internal implementation
    //abstraction is achieved using abstract class and interfaces
    public abstract class payment
    {
        
        public string Transactionid {  get; set; }
        private int val;
        public int Amount { get { return val; } set { if (value > 0) val = value; } }
        public payment(int amount)
        {
            this.Amount = amount;
        }

        public abstract void processpayment();
        public void printtransactiondetails()
        {
            Console.WriteLine($"transaction id:{Transactionid}");
        }
    }
    public class creditcardpayment : payment {

        public creditcardpayment(int amount) : base(amount) {
          
        }
    
        public override void processpayment()
        {
            Console.WriteLine($"processing payment of  amount{base.Amount}");
        }
    }
    public class UPIpayment : payment
    {
        public UPIpayment(int amount) : base(amount) { }
        public override void processpayment()
        {
            Console.WriteLine($"processing payment of  amount{this.Amount}");
        }
    }


}
