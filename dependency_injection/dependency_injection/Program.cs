// See https://aka.ms/new-console-template for more information

using System.Net.Http.Headers;
using dependency_injection;

PaymentWithoutDI paywithoutDI = new PaymentWithoutDI();
paywithoutDI.makepaymentwithoutDI();

Ipayment paying = new Creditcard();
//Ipayment paying=new Creditcard();
PaymentWithConstructorDI paywithconst = new PaymentWithConstructorDI(paying);
paywithconst.makepayment();

Ipayment paying2 = new UPI();
PaymentWithPropertiesDI paywithprop = new PaymentWithPropertiesDI();
paywithprop.Pay = paying2;
paywithprop.Makepayment();

Ipayment paying3 = new Creditcard();
PaymentWithMethodDI paywithmethod = new PaymentWithMethodDI();
paywithmethod.Makepay(paying3);