using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP
{
    internal class UserManager
    {
        private readonly validation _validation = new validation();
        private readonly logging _logging = new logging();

        public void CreateUser(string username, string password)
        {
            if (_validation.ValidatePassword(password))
            {
                _logging.LogInfo("user created successfully");
            }

            else
            {
                _logging.LogError("password doesnot meet requirements");
            }
        }

    }
}
