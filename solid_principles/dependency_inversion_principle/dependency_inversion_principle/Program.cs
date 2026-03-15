// See https://aka.ms/new-console-template for more information

using dependency_inversion_principle;
//without using dip
Userservice userservice = new Userservice();
userservice.RegisterUser("alice@gmail.com");

//using dip
INotificationsender isend=new EmailSender();
Userservice_using_DIP u_service = new Userservice_using_DIP(isend);
u_service.RegisterUser("alice@gmail.com");
INotificationsender isms = new SMSsender();
Userservice_using_DIP u_sms = new Userservice_using_DIP(isms);
u_sms.RegisterUser("paavani");
