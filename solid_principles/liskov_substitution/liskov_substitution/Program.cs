// See https://aka.ms/new-console-template for more information

//without liskov

using System;
using liskov_substitution;

Employee fulltimeemp = new fulltimeemployee("pavithra");
Console.WriteLine($"salary of full time employee {fulltimeemp.calculatesalary()}");

//using liskov
employee_abstract e = new fte("bob", 100000);
Console.WriteLine($"salary of full time employee {e.calculateMonthpayment()}");
employee_abstract temp = new intern("sarnya", 15, 100);
Console.WriteLine($"salary of intern {temp.calculateMonthpayment()}");


