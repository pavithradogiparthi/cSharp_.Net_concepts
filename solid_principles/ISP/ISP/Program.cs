// See https://aka.ms/new-console-template for more information
using ISP;
//without isp
orderprocessor op = new onlineorderprocessor();
op.processonlineorder();
orderprocessor inshop = new instoreorderprocessor();
inshop.processinstorepickuporder();
inshop.applydiscount();

//using isp
Ionlineorderprocessing i = new onlineorderprocessimp();
i.processingonlineorder();
Iinstoreorderprocessing ip= new instoreorderprocessimp();
ip.instorepickuporder();






