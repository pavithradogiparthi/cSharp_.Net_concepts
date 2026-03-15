// See https://aka.ms/new-console-template for more information
using ocp;
double amount = 10000;
regularcustomerdiscount r=new regularcustomerdiscount();
discountcalculator reg_calculator = new discountcalculator(r);
Console.WriteLine($"regular  discount  {reg_calculator.calculatediscount(amount)}");

discountcalculator emp_cal = new discountcalculator(new VIPCustomerdiscount());
Console.WriteLine($"employee discount {emp_cal.calculatediscount(amount)}");

discountcalculator VIP = new discountcalculator(new VIPCustomerdiscount());
Console.WriteLine($"VIP  discount {VIP.calculatediscount(amount)}");

//dicount without ocp
discountcalculator_without_ocp cu=new discountcalculator_without_ocp();
Console.WriteLine(cu.CalculateDiscount(Customertype.random,amount));






