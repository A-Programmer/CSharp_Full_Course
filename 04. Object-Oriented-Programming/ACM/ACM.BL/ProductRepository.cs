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
        return product;
    }

    /// <summary>
    /// Saves the current Product
    /// </summary>
    public bool Save(Product product)
    {
        return true;
    }
}