using System.Text;

namespace LINQSamples
{
  public class SamplesViewModel : ViewModelBase
  {
 
        public List<Product>GetAllQuery()
        {
            List<Product> products = GetProducts();
            List<Product> list = new();
            list = (from prod in products select prod).ToList();
                return list;
        }

  
   
    public List<Product> GetAllMethod()
    {
      List<Product> products = GetProducts();
            List<Product> list = new();
            //list = Queryable; and return list
      return  products.Select(prod => prod).ToList();
  
    }
   

   
    public List<string> GetSingleColumnQuery()
    {
      List<Product> products = GetProducts();
      List<string> list = new();

            // Write Query Syntax Here
            list.AddRange(from prod in products select prod.Name);
            //list = (from prod in products select prod.Name).tolist();
           
      

      return list;
    }
   

    
    public List<string> GetSingleColumnMethod()
    {
      List<Product> products = GetProducts();
      List<string> list = new();

            // Write Method Syntax Here

            list.AddRange(products.Select(prod => prod.Name));
      return list;
    }
   


    public List<Product> GetSpecificColumnsQuery()
    {
      List<Product> products = GetProducts();
      List<Product> list = new();

            // Write Query Syntax Here

            list = (from prod in products
                    select new Product
                    {
                        ProductID = prod.ProductID,
                        Name = prod.Name,
                        Size = prod.Size

                    }).ToList();
                  
      return list;
    }
  

    public List<Product> GetSpecificColumnsMethod()
    {
      List<Product> products = GetProducts();
      List<Product> list = new();

            // Write Method Syntax Here
            products.Select(prod => new  { ProductID = prod.ProductID,
                Name=prod.Name ,
                Size=prod.Size
            }).ToList();



            return list;
    }
   


    public string AnonymousClassQuery()
    {
      List<Product> products = GetProducts();
      StringBuilder sb = new(2048);

            // Write Query Syntax Here

            var list = (from prod in products
                        select new
                        {
                            Identifier = prod.ProductID,
                            ProductName = prod.Name,
                            ProductSize = prod.Size

                        });
           // Loop through anonymous class
      foreach (var prod in list)
      {
        sb.AppendLine($"Product ID: {prod.Identifier}");
        sb.AppendLine($"   Product Name: {prod.ProductName}");
        sb.AppendLine($"   Product Size: {prod.ProductSize}");
      }

      return sb.ToString();
    }
    

   
    public string AnonymousClassMethod()
    {
      List<Product> products = GetProducts();
      StringBuilder sb = new(2048);

            // Write Method Syntax Here
            var list = products.Select(p => new { Identifier = p.ProductID,
            ProductName=p.Name,
            ProductSize=p.Size});

            // Loop through anonymous class
            foreach (var prod in list)
            {
                sb.AppendLine($"Product ID: {prod.Identifier}");
                sb.AppendLine($"   Product Name: {prod.ProductName}");
                sb.AppendLine($"   Product Size: {prod.ProductSize}");
            }

            return sb.ToString();
    }
        public List<Product> OrderByQuery()
        {
            List<Product> products = GetProducts();
            List<Product> list = new();
            list = (from prod in products  orderby prod.Color select prod).ToList();
            return list;
        }
        public List<Product> OrderByMethod()
        {
            List<Product> products = GetProducts();
            List<Product> list = new();
            products.OrderBy(prod => prod.Name).ToList();
            return list;
        }
        public List<Product> OrderByQueryDesc()
        {
            List<Product> products = GetProducts();
            List<Product> list = new();
            list = (from prod in products orderby prod.Color descending select prod).ToList();
            return list;
        }
        public List<Product> OrderByMethodDesc()
        {
            List<Product> products = GetProducts();
            List<Product> list = new();
            products.OrderByDescending(prod => prod.Name).ToList();
            return list;
        }
        public List<Product> OrderByTwoFields()
        {
            List<Product> products = GetProducts();
            List<Product> list = new();
            list = (from prod in products orderby prod.Color descending, prod.Name  select prod).ToList();
            return list;
        }
        public List<Product> OrderByTwoFieldsMethodDesc()
        {
            List<Product> products = GetProducts();
            List<Product> list = new();
          list=  products.OrderByDescending(prod => prod.Color)
                .ThenBy(prod=>prod.Name).ToList();
            return list;
        }
        public List<Product> OrderByTwoFieldsDescMethodDesc()
        {
            List<Product> products = GetProducts();
            List<Product> list = new();
            list = products.OrderByDescending(prod => prod.Color)
                  .ThenByDescending(prod => prod.Name).ToList();
            return list;
        }
        public List<Product> WhereQuery()
        {
            List<Product> products = GetProducts();
            List<Product> list = new();
            list = (from prod in products where prod.Name.StartsWith("S") select prod).ToList();
            return list;
        }
        public List<Product> WhereMethod()
        {
            List<Product> products = GetProducts();
            List<Product> list = new();
            // list = products.Where(p => { Console.WriteLine("1"); return p.Color == "Black"; }).Select(p => p.ProductID).ToList();
            list = products.Where(p => p.Name.StartsWith("S")).ToList();
            return list;
        }
        public List<Product>WhereTwoFieldsQuery()
        {
            List<Product> products = GetProducts();
            List<Product> list = new();
            list = (from prod in products
                    where prod.ProductID>700
                   && prod.StandardCost > 100
                    select prod).ToList();
            return list;
        }
        public List<Product>WhereTwoFieldsMethod()
        {
            List<Product> products = GetProducts();
            return (products.Where(p => p.ProductID >700 && p.StandardCost > 100)).ToList();
        }
        public List<Product> WhereExtensionQuery()
        {
            List<Product> products = GetProducts();
            List<Product> list = new();
            list = (from prod in products
                 
                    select prod).ByColor("Red").ToList();
            return list;
        }
        public List<Product> WhereExtensionMethod()
        {
            List<Product> products = GetProducts();
            return (products.ByColor("Red")).ToList();
        }
    }
}
