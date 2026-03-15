using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP
{
    internal class validation
    {

        public  bool ValidatePassword(string password)
        {
            // Checks password strength (e.g., length, special characters, etc.)
            return password.Length >= 8 && password.Any(char.IsDigit);
        }
    }
}
