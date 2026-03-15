using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dependency_inversion_principle
{
    public interface INotificationsender
    {
        void Send(string to, string subject);
    }
    public class EmailSender : INotificationsender
    {
        public void Send(string to, string subject)
        {
            Console.WriteLine($"email sent to{to} with subject {subject} using DIP");
        }
    }
        public class SMSsender : INotificationsender
        {
            public void Send(string to, string subject)
            {
                Console.WriteLine($" sms sent to{to} with subject {subject}");
            }
        }
    public class Userservice_using_DIP
    {
        private readonly INotificationsender notificationsender;
        public Userservice_using_DIP(INotificationsender inotificationsender)
        {
            notificationsender = inotificationsender;
        }
        public void RegisterUser(string email)
        {
            Console.WriteLine("user registered using DIP ");
            notificationsender.Send(email, "welcome msg");
        }

    }

    
}
