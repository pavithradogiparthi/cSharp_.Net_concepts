
using EntityFramework.Data;
using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;


using ApplicationDbContext context = new ApplicationDbContext();
//Products veggispecial = new Products()
//{Name="veggie special",
//Price=99

//};
//context.Products.Add(veggispecial);
//Products meat = new()
//{ Price=100,
//Name="meat"
//};
//context.Add(meat);
//context.SaveChanges();
//var veggiespecial = context.Products.Where(p => p.Name == "veggie special").FirstOrDefault();
//if(veggiespecial is Products)
//{
//    veggiespecial.Price = 110;
//    context.Remove(veggiespecial);
//}
context.SaveChanges();
var products = context.Products.Where(p => p.Id==2).FirstOrDefault();
var product = context.Products.Where(p => p.Price >= 100);

foreach(Products p in  product)
{
    Console.WriteLine($"Id:{p.Id}");
    Console.WriteLine($"Name:{p.Name}");
    Console.WriteLine($"price:{p.Price}");
    Console.WriteLine("====");
}
//products.Name = "hiiiii";

context.SaveChanges();

