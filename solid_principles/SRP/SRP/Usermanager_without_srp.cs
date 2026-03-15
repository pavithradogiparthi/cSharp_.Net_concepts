using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP
{
    internal class Usermanager_without_srp
    {
        public void createuser(string username, string password)
        {
            if(password.Length >= 8 && password.Any(char.IsDigit))
            {
                Console.WriteLine("user created successfully");
            }
            else
            {
                Console.WriteLine("Invalid credentials");
            }
        }
    }
}
