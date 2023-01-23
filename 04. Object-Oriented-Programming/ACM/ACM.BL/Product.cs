namespace ACM.BL;

public class Product
{
    public Product()
    {
        
    }

    public Product(int productId)
    {
        ProductId = productId;
    }

    public decimal? CurrentPrice { get; set; }
    public string ProductDescription { get; set; }
    public int ProductId { get; private set; }
    public string ProductName { get; set; }

    public bool Validate()
    {
        bool isValid = true;

        if (string.IsNullOrWhiteSpace(ProductName)) isValid = false;
        if (CurrentPrice is null) isValid = false;

        return isValid;
    }
}