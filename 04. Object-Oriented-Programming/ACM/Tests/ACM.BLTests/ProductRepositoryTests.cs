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

    [Fact]
    public void SaveTestValid()
    {
        ProductRepository repository = new();
        Product updatedProduct = new(2)
        {
            CurrentPrice = 18M,
            ProductDescription = "Updated Description",
            ProductName = "Sunflowers",
            HasChanges = true
        };

        bool actual = repository.Save(updatedProduct);

        Assert.Equal(true, actual);
    }

    [Fact]
    public void SaveTestMissingPrice()
    {
        ProductRepository repository = new();
        Product updatedProduct = new(2)
        {
            CurrentPrice = null,
            ProductDescription = "Updated Description",
            ProductName = "Sunflowers",
            HasChanges = true
        };

        bool actual = repository.Save(updatedProduct);

        Assert.Equal(false, actual);
    }
}