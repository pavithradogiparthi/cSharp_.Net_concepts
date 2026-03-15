using System.Runtime;

namespace LINQSamples
{
  public class SamplesViewModel : ViewModelBase
  {
   
    public Product FirstQuery()
    {
      List<Product> products = GetProducts();
      Product value = null;

            // Write Query Syntax Here
            value = (from prod in products select prod).First(prod=>prod.Color=="Purple");

      // Test the exception handling

      return value;
    }
  

    public Product FirstMethod()
    {
      List<Product> products = GetProducts();
      Product value = null;
            value = products.First(p => p.Color == "Purple");

      // Write Method Syntax Here
      
      return value;
    }
  

   
    public Product FirstOrDefaultQuery()
    {
      List<Product> products = GetProducts();
      Product value = null;

            // Write Query Syntax Here
            value = (from prod in products select prod)
                .FirstOrDefault(prod => prod.Color == "Red"
                ,new Product { ProductID=-1,Name="Not Found"});

      // Test the exception handling

      return value;
    }
 

   
    public Product FirstOrDefaultMethod()
    {
      List<Product> products = GetProducts();
      Product value = null;
       

            // Write Method Syntax Here
            value = products.FirstOrDefault(p => p.Color == "Red",
                new Product { ProductID=-1,Name="NOT FOUND"});

      return value;
    }
   


    public Product FirstOrDefaultWithDefaultQuery()
    {
      List<Product> products = GetProducts();
      Product value = null;
            products = null;

            // Write Query Syntax Here

            // Test the exception handling

            return value;
    }

    #region FirstOrDefaultWithDefaultMethod
    /// <summary>
    /// Locate a specific product using FirstOrDefault(). FirstOrDefault() searches forward in the list.
    /// NOTE: You may specify the return value with FirstOrDefault() if not found
    /// Use FirstOrDefault() when you DON'T know if a collection might have one element you are looking for
    /// Using FirstOrDefault() avoids throwing an exception which can hurt performance
    /// </summary>
    public Product FirstOrDefaultWithDefaultMethod()
    {
      List<Product> products = GetProducts();
      Product value = null;

      // Write Method Syntax Here

      return value;
    }
    #endregion

    public Product LastQuery()
    {
      List<Product> products = GetProducts();
      Product value = null;

            // Write Query Syntax Here
            value = (from prod in products select prod).Last(prod => prod.Color == "Red");
      
      // Test the exception handling
      
      return value;
    }
 

    public Product LastMethod()
    {
      List<Product> products = GetProducts();
      Product value = null;
 

            // Write Method Syntax Here
            value = products.Last(p => p.Color == "Red");

      return value;
    }


  
    public Product LastOrDefaultQuery()
    {
      List<Product> products = GetProducts();
      Product value = null;

            // Write Query Syntax Here
            value = (from prod in products select prod).
                LastOrDefault(prod => prod.Color == "Red",
                new Product { ProductID=-1,Name="Not Found"});

      // Test the exception handling
     
      return value;
    }
    

    
    public Product LastOrDefaultMethod()
    {
      List<Product> products = GetProducts();
      Product value = null;
          

            // Write Method Syntax Here
       value=     products.LastOrDefault(p => p.Color == "Red",
                new Product { ProductID=-1,Name="Not Found"
            });
      

      return value;
    }


 
    public Product SingleQuery()
    {
      List<Product> products = GetProducts();
            
      Product value = null;
            //products=null argumentnull exception

            // Write Query Syntax Here
             value = (from prod in products select prod).Single(prod => prod.ProductID == 706);
            //value = (from prod in products select prod).
            //Single(prod => prod.Color == "Red");invalid operation exception

     

      return value;
    }
 

   
    public Product SingleMethod()
    {
      List<Product> products = GetProducts();
      Product value = null;

            // Write Method Syntax Here
            value = products.Single(p => p.Color=="Purple");

      return value;
    }

  
    public Product SingleOrDefaultQuery()
    {
      List<Product> products = GetProducts();
      Product value = null;

            // Write Query Syntax Here
            value = (from prod in products select prod).
             SingleOrDefault(prod => prod.ProductID == 706);

            // Test the exception handling for finding multiple values
            try
            {
                value = (from prod in products select prod).
         SingleOrDefault(prod => prod.Color == "Red");
            }
            catch (Exception ex)
            {
                Console.WriteLine( ex.Message);
            }
            

            // Test the exception handling for the list is empty
            //products.Clear();
            value = (from prod in products select prod).
                SingleOrDefault(prod => prod.ProductID ==708 );

            // Test the exception handling for the list is empty and a default value is supplied

            //value = (from prod in products select prod)
            //    .SingleOrDefault(prod => prod.ProductID == 706,
            //    new Product { ProductID = -1, Name = "No products in the list" });
            // Test the exception handling for the list is null


            return value;
    }
  

    public Product SingleOrDefaultMethod()
    {
      List<Product> products = GetProducts();
      Product value = null;

            // Write Method Syntax Here
            value = products.SingleOrDefault(prod => prod.ProductID == 706);

      return value;
    }
  
  }
}
