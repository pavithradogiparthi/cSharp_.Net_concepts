// See https://aka.ms/new-console-template for more information
using oops;
//polymorphism

math m=new math();
 int temp =m.add(12, 13);
float ans = m.add(12.0f, 13.2f, 23.4f);
Console.WriteLine(temp);
Console.WriteLine(ans);
Animal animal = new Animal();
animal.speak();

Animal dog= new Dog();
dog.speak();
//abstraction using abstract class

payment p1= new creditcardpayment(-10);
p1.Transactionid = "1234";
p1.processpayment();
p1.printtransactiondetails();



//abstraction using interfaces
Ishape cir = new circle(8);
 double cir_area=cir.calculatearea();
Console.WriteLine(cir_area);
Ishape s = new square(2, 6);
 double sq_area=s.calculatearea();
Console.WriteLine(sq_area);

//encapsualtion
bankaccount b = new bankaccount("987654332", -10);
Console.WriteLine(b.Rateof_intrest);
Console.WriteLine(b.Accountno);