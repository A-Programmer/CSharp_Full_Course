using ACM.BL;
using ACM.Common;

namespace ACM.CommonTests;

public class LoggingServiceTests
{
    [Fact]
    public void WriteToFileTest()
    {
        List<ILoggable> changedItems = new();

        Customer customer = new(1)
        {
            EmailAddress = "MrSadin@Gmail.Com",
            FirstName = "Kamran",
            LastName = "Sadin",
            AddessList = null
        };
        changedItems.Add(customer);

        Product product = new(2)
        {
            ProductName = "Rake",
            ProductDescription = "Garden Rake with steel head",
            CurrentPrice = 6M
        };
        changedItems.Add(product);

        LoggingService.WriteToFile(changedItems);
    }
}