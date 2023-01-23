using ACM.BL;

namespace ACM.BLTests;

public class OrderRepositoryTests
{
    [Fact]
    public void RetriveTest()
    {
        OrderRepository repo = new();
        Order expected = new(10)
        {
            OrderDate = new(DateTime.Now.Year, 4, 14, 10, 00, 00,
                new TimeSpan(7, 0, 0))
        };

        Order actual = repo.Retrive(10);
        
        Assert.Equal(expected.OrderDate, actual.OrderDate);
    }
}