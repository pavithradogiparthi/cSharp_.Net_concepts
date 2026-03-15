using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oops
{
    public class bankaccount
    {
        private string accountno;
        private decimal balance;
        private double roi;
        public double Rateof_intrest { get { return roi; }  
            private set { roi = 0.05; } }

        public string Accountno { get { return accountno; } }
        public decimal Balance
        {
            get { return balance; }
            private set
            {
                if (value >= 0) balance = value;
                else { Console.WriteLine("balance cnt be neagtive"); }
            }
        }
        public  bankaccount(string temp,decimal bal)
        {
            accountno= temp;
            Balance = bal;
            Rateof_intrest=0;
        }
    }

}
