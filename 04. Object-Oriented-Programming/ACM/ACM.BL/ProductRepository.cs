namespace ACM.BL;

public class ProductRepository
{
    /// <summary>
    /// Retrives one Product.
    /// </summary>
    public Product Retrive(int productId)
    {
        Product product = new Product(productId);

        if (productId == 2)
        {
            product.ProductName = "Sunflowers";
            product.ProductDescription = "Desc";
            product.CurrentPrice = 15.96M;
        }
        Object myObject = new();
        Console.WriteLine($"Object: {myObject.ToString()}");
        Console.WriteLine($"Object: {product.ToString()}");
        return product;
    }

    /// <summary>
    /// Saves the current Product
    /// </summary>
    public bool Save(Product product)
    {
        bool success = true;
        if(product.HasChanges)
        {
            if(product.IsValid)
            {
                if(product.IsNew)
                {
                    // Call an Insert Stored Procedure
                }
                else
                {
                    // Call an Update Strored Procedure
                }
            }
            else
            {
                success = false;
            }
        }
        return success;
    }
}