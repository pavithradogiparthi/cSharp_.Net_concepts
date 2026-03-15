using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dependency_inversion_principle
{
    public class Emailservice
    {
        public void Sendemail(string to, string subject)
        {
            Console.WriteLine($" email sent to {to} with subject {subject}"); 
        }

    }
    public class Userservice
    {
        private Emailservice emailservice;
        public  Userservice()
        {
            emailservice = new Emailservice();
        }
        public void RegisterUser(string email)
        {
            Console.WriteLine("user registered");
            emailservice.Sendemail(email, "welcome msg");
        }

    }

}
