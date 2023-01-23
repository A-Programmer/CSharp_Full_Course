using ACM.BL;

namespace ACM.BLTests;

public class ProductRepositoryTests
{
    [Fact]
    public void RetriveTest()
    {
        ProductRepository repo = new();
        Product expected = new(2)
        {
            CurrentPrice = 15.96M,
            ProductDescription = "Desc",
            ProductName = "Sunflowers"
        };

        Product actual = repo.Retrive(2);
        
        Assert.Equal(expected.CurrentPrice, actual.CurrentPrice);
        Assert.Equal(expected.ProductName, actual.ProductName);
        Assert.Equal(expected.ProductDescription, actual.ProductDescription);
    }
}