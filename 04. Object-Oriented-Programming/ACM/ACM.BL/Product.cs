using ACM.Common;

namespace ACM.BL;
public class Product : EntityBase
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
    private string _productName;
    public string ProductName
    {
        get
        {
            return _productName.InsertSpaces();
        }
        set
        {
            _productName = value;
        }
    }

    public override bool Validate()
    {
        bool isValid = true;

        if (string.IsNullOrWhiteSpace(ProductName)) isValid = false;
        if (CurrentPrice is null) isValid = false;

        return isValid;
    }

    public override string ToString() => ProductName;
}