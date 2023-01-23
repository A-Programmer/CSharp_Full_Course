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

    [Fact]
    public void RetriveExistingWithAddress()
    {
        CustomerRepository customerRepository = new();
        Customer expected = new(1)
        {
            EmailAddress = "MrSadin@Gmail.Com",
            FirstName = "Kamran",
            LastName = "Sadin",
            AddessList = new List<Address>()
                {
                    new Address()
                    {
                        AddressType = 1,
                        StreetLine1 = "Street 1",
                        StreetLine2 = "Street 2",
                        City = "Gonbade Kavous",
                        State = "Golestan",
                        Country = "Iran",
                        PostalCode = "123456789"
                    },
                    new Address()
                    {
                        AddressType = 2,
                        StreetLine1 = "Street 3",
                        StreetLine2 = "Street 4",
                        City = "Gonbade Kavous",
                        State = "Golestan",
                        Country = "Iran",
                        PostalCode = "987654321"
                    }
                }
        };
        Customer actual = customerRepository.Retrive(1);

        Assert.Equal(expected.CustomerId, actual.CustomerId);
        Assert.Equal(expected.EmailAddress, actual.EmailAddress);
        Assert.Equal(expected.FirstName, actual.FirstName);
        Assert.Equal(expected.LastName, actual.LastName);

        for (int i = 0; i < 1; i++)
        {
            Assert.Equal(expected.AddessList[i].AddressType, actual.AddessList[i].AddressType);
            Assert.Equal(expected.AddessList[i].StreetLine1, actual.AddessList[i].StreetLine1);
            Assert.Equal(expected.AddessList[i].City, actual.AddessList[i].City);
            Assert.Equal(expected.AddessList[i].State, actual.AddessList[i].State);
            Assert.Equal(expected.AddessList[i].Country, actual.AddessList[i].Country);
            Assert.Equal(expected.AddessList[i].PostalCode, actual.AddessList[i].PostalCode);
        }
    }
}