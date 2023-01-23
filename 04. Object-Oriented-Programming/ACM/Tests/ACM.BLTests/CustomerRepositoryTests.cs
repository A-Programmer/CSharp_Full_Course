using ACM.BL;

namespace ACM.BLTests;

public class CustomerRepositoryTests
{
    [Fact]
    public void RetriveValid()
    {
        CustomerRepository customerRepository = new();
        Customer expected = new(1)
        {
            EmailAddress = "MrSadin@Gmail.Com",
            FirstName = "Kamran",
            LastName = "Sadin"
        };
        Customer actual = customerRepository.Retrive(1);
        
        Assert.Equal(expected.EmailAddress, actual.EmailAddress);
        Assert.Equal(expected.FirstName, actual.FirstName);
        Assert.Equal(expected.LastName, actual.LastName);
    }
}