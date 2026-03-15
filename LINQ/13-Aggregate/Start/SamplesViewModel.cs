namespace LINQSamples
{
  public class SamplesViewModel : ViewModelBase
  {
    #region CountQuery
    /// <summary>
    /// Gets the total number of products in a collection
    /// </summary>
    public int CountQuery()
    {
      int value = 0;
      // Load all Product Data
      List<Product> products = ProductRepository.GetAll();

            // Write Query Syntax Here
            value = (from prod in products select prod).Count();

      return value;
    }
    #endregion

    #region CountMethod
    /// <summary>
    /// Gets the total number of products in a collection
    /// </summary>
    public int CountMethod()
    {
      int value = 0;
      // Load all Product Data
      List<Product> products = ProductRepository.GetAll();

            // Write Method Syntax Here

            value = products.Count;
      return value;
    }
    #endregion

    #region CountFilteredQuery
    /// <summary>
    /// Can either add a where clause or a predicate in the Count() method
    /// </summary>
    public int CountFilteredQuery()
    {
      int value = 0;
      // Load all Product Data
      List<Product> products = ProductRepository.GetAll();

            // Write Query Syntax #1 Here

            value = (from prod in products select prod).Count(prod => prod.Color == "Red");
            // Write Query Syntax #2 Here
            value = (from prod in products where prod.Color == "Red" select prod).Count();

      return value;
    }
    #endregion

    #region CountFilteredMethod
    /// <summary>
    /// Gets the total number of products in a collection
    /// </summary>
    public int CountFilteredMethod()
    {
      int value = 0;
      // Load all Product Data
      List<Product> products = ProductRepository.GetAll();

            // Write Method Syntax #1 Here
            value = products.Count(p => p.Color == "Red");


            // Write Method Syntax #2 Here
            value = products.Where(p => p.Color == "Red").Count();
      

      return value;
    }
    #endregion

    #region MinQuery
    /// <summary>
    /// Get the minimum value of a single property in a collection
    /// </summary>
    public decimal MinQuery()
    {
      decimal value = 0;
      // Load all Product Data
      List<Product> products = ProductRepository.GetAll();

      // Write Query Syntax #1 Here
     value=(from  prod in products select prod.ListPrice).Min();

            // Write Query Syntax #2 Here
            value = (from prod in products select prod).Min(prod=>prod.ListPrice);

      return value;
    }
    #endregion

    #region MinMethod
    /// <summary>
    /// Get the minimum value of a single property in a collection
    /// </summary>
    public decimal MinMethod()
    {
      decimal value = 0;
      // Load all Product Data
      List<Product> products = ProductRepository.GetAll();

            // Write Method Syntax #1 Here
            value = products.Min(prod => prod.ListPrice);

            // Write Method Syntax #2 Here

            value = products.Select(p => p.ListPrice).Min();
      return value;
    }
    #endregion

    #region MaxQuery
    /// <summary>
    /// Get the maximum value of a single property in a collection
    /// </summary>
    public decimal MaxQuery()
    {
      decimal value = 0;
      // Load all Product Data
      List<Product> products = ProductRepository.GetAll();

            // Write Query Syntax #1 Here
            value = (from prod in products select prod.ListPrice).Max();

            // Write Query Syntax #2 Here
            value = (from prod in products select prod).Max(prod => prod.ListPrice);

            return value;
    }
    #endregion

    #region MaxMethod
    /// <summary>
    /// Get the maximum value of a single property in a collection
    /// </summary>
    public decimal MaxMethod()
    {
      decimal value = 0;
      // Load all Product Data
      List<Product> products = ProductRepository.GetAll();

            // Write Method Syntax #1 Here
            value = products.Max(prod => prod.ListPrice);

            // Write Method Syntax #2 Here
            value = products.Select(p => p.ListPrice).Max();

            return value;
    }
    #endregion

    #region MinByQuery
    /// <summary>
    /// Get the minimum value of a single property in a collection, but return the object
    /// </summary>
    public Product MinByQuery()
    {
      Product product = null;
      // Load all Product Data
      List<Product> products = ProductRepository.GetAll();

            // Write Query Syntax Here
            product = (from prod in products select prod).MinBy(prod => prod.ListPrice);

      return product;
    }
    #endregion

    #region MinByMethod
    /// <summary>
    /// Get the minimum value of a single property in a collection, but return the object
    /// </summary>
    public Product MinByMethod()
    {
      Product product = null;
      // Load all Product Data
      List<Product> products = ProductRepository.GetAll();

            // Write Method Syntax Here
            product = products.MinBy(p => p.ListPrice);

      return product;
    }
    #endregion

    #region MaxByQuery
    /// <summary>
    /// Get the maximum value of a single property in a collection, but return the object
    /// </summary>
    public Product MaxByQuery()
    {
      Product product = null;
      // Load all Product Data
      List<Product> products = ProductRepository.GetAll();

            // Write Query Syntax Here

            product = (from prod in products select prod).MaxBy(prod => prod.ListPrice);
            return product;
    }
    #endregion

    #region MaxByMethod
    /// <summary>
    /// Get the maximum value of a single property in a collection, but return the object
    /// </summary>
    public Product MaxByMethod()
    {
      Product product = null;
      // Load all Product Data
      List<Product> products = ProductRepository.GetAll();

            // Write Method Syntax Here

            product = products.MaxBy(p => p.ListPrice);
            return product;
    }
    #endregion

    #region AverageQuery
    /// <summary>
    /// Get the average of all values within a single property in a collection
    /// </summary>
    public decimal AverageQuery()
    {
      decimal value = 0;
      // Load all Product Data
      List<Product> products = ProductRepository.GetAll();

            // Write Query Syntax #1 Here
            value= (from prod in products select prod).Average(prod => prod.ListPrice);

            // Write Query Syntax #2 Here

            value = (from prod in products select prod.ListPrice).Average();
            return value;
    }
    #endregion

    #region AverageMethod
    /// <summary>
    /// Get the average of all values within a single property in a collection
    /// </summary>
    public decimal AverageMethod()
    {
      decimal value = 0;
      // Load all Product Data
      List<Product> products = ProductRepository.GetAll();

            // Write Method Syntax #1 Here
         value=   products.Average(p => p.ListPrice);

            // Write Method Syntax #2 Here

            value = products.Select(p => p.ListPrice).Average();
      return value;
    }
    #endregion

    #region SumQuery
    /// <summary>
    /// Gets the sum of the values of a single property in a collection
    /// </summary>
    public decimal SumQuery()
    {
      decimal value = 0;
      // Load all Product Data
      List<Product> products = ProductRepository.GetAll();

            // Write Query Syntax #1 Here
            value = (from prod in products select prod).Sum(prod => prod.ListPrice);

            // Write Query Syntax #2 Here

            value = (from prod in products select prod.ListPrice).Sum();
            return value;
    }
    #endregion

    #region SumMethod
    /// <summary>
    /// Gets the sum of the values of a single property in a collection
    /// </summary>
    public decimal SumMethod()
    {
      decimal value = 0;
      // Load all Product Data
      List<Product> products = ProductRepository.GetAll();

            // Write Method Syntax #1 Here

            value = products.Select(p => p.ListPrice).Sum();
            // Write Method Syntax #1 Here

            value = products.Sum(p => p.ListPrice);
            return value;
    }
    #endregion

    #region AggregateQuery
    /// <summary>
    /// Aggregate allows you to iterate over a collection and perform an accumulation of values. With this operator you can simulate count, sum, etc.
    /// </summary>
    public decimal AggregateQuery()
    {
      decimal value = 0;
      // Load all Product Data
      List<Product> products = ProductRepository.GetAll();

            // Write Query Syntax Here

            value = (from prod in products select prod).Aggregate(0M,
                (sum, Prod) => sum += Prod.ListPrice);
      return value;
    }
    #endregion

    #region AggregateMethod
    /// <summary>
    /// Aggregate allows you to iterate over a collection and perform an accumulation of values. With this operator you can simulate count, sum, etc.
    /// </summary>
    public decimal AggregateMethod()
    {
      decimal value = 0;
      // Load all Product Data
      List<Product> products = ProductRepository.GetAll();

            // Write Method Syntax Here
            value = products.Aggregate(0M, (sum, prod) => sum += prod.ListPrice);

      return value;
    }
    #endregion

    #region AggregateCustomQuery
    /// <summary>
    /// Use Sales Orders and calculate the total Sales by multiplying OrderQty * UnitPrice for each order
    /// </summary>
    public decimal AggregateCustomQuery()
    {
      decimal value = 0;
      // Load all Sales Data
      List<SalesOrder> sales = SalesOrderRepository.GetAll();

            // Write Query Syntax Here

            value = (from sale in sales select sale).Aggregate(0M, (sum, sale) =>
            sum += (sale.OrderQty * sale.UnitPrice));
            return value;
    }
    #endregion

    #region AggregateCustomMethod
    /// <summary>
    /// Use Sales Orders and calculate the total Sales by multiplying OrderQty * UnitPrice for each order
    /// </summary>
    public decimal AggregateCustomMethod()
    {
      decimal value = 0;
      // Load all Sales Data
      List<SalesOrder> sales = SalesOrderRepository.GetAll();

            // Write Method Syntax Here
            value = sales.Aggregate(0M, (sum, sale) => sum += (sale.OrderQty * sale.UnitPrice));

      return value;
    }
    #endregion

    #region AggregateUsingGroupByQuery
    /// <summary>
    /// Group products by Size property and calculate min/max/average prices
    /// </summary>
    public List<ProductStats> AggregateUsingGroupByQuery()
    {
      List<ProductStats> list = null;
      // Load all Sales Data
      List<Product> products = ProductRepository.GetAll();

            // Write Query Syntax Here

            list = (from prod in products
                    group prod by prod.Size into sizegroup
                    where sizegroup.Count() > 0
                    select new ProductStats { 
                        Size=sizegroup.Key,
                        TotalProducts=sizegroup.Count(),
                        MinListPrice=sizegroup.Min(s=>s.ListPrice),
                        MaxListPrice=sizegroup.Max(s=>s.ListPrice),
                        AverageListPrice=sizegroup.Average(s=>s.ListPrice)
                    } into result orderby result.Size select result).ToList();

            return list;
    }
    #endregion

    #region AggregateUsingGroupByMethod
    /// <summary>
    /// Group products by Size property and calculate min/max/average prices
    /// </summary>
    public List<ProductStats> AggregateUsingGroupByMethod()
    {
      List<ProductStats> list = null;
      // Load all Sales Data
      List<Product> products = ProductRepository.GetAll();

            // Write Method Syntax Here
            list = products.GroupBy(sale => sale.Size).Select(sizegroup => new ProductStats {
                Size=sizegroup.Key ,
                TotalProducts = sizegroup.Count(),
                MinListPrice = sizegroup.Min(s => s.ListPrice),
                MaxListPrice = sizegroup.Max(s => s.ListPrice),
                AverageListPrice = sizegroup.Average(s => s.ListPrice)
            }).ToList();


            return list;
    }
    #endregion

    #region AggregateMoreEfficientMethod
    /// <summary>
    /// Use Aggregate with some custom methods to gather the data in one pass 
    /// </summary>
    public List<ProductStats> AggregateMoreEfficientMethod()
    {
      List<ProductStats> list = null;
      // Load all Sales Data
      List<Product> products = ProductRepository.GetAll();

            // Write Method Syntax Here
            list = products.GroupBy(sale => sale.Size).
                      Where(sizegroup => sizegroup.Count() > 0)
                      .Select(sizegroup =>
                      {
                          ProductStats acc = new()
                          { Size = sizegroup.Key };
                          sizegroup.Aggregate(acc, (acc, prod) => acc.Accumulate(prod), acc => acc.ComputeAverage());
                          return acc;
                      }).OrderBy(result => result.Size).ToList();

      return list;
    }
    #endregion
  }
}
