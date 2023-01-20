using ACM.BL;

namespace ACM.BLTests;

public class CustomerTests
{
    [Fact]
    public void FullNameTestValid()
    {
        // Arrange
        var customer = new Customer();
        customer.FirstName = "Kamran";
        customer.LastName = "Sadin";
        
        // Act
        var customerFullName = customer.FullName;

        // Assert
        Assert.Equal("Sadin, Kamran", customerFullName);
    }

    [Fact]
    public void FullNameLastNameEmpty()
    {
        // Arrenge
        Customer customer = new Customer
        {
            FirstName = "Kamran"
        };
        string expected = "Kamran";

        // Act
        string actual = customer.FullName;


        var i1 = 43;
        var i2 = i1;
        i2 = 2;

        var customer1 = new Customer
        {
            FirstName = "Kamran",
            Age = 34
        };

        var customer2 = customer1;

        customer2.FirstName = "Amir";
        customer2.Age = 30;

        Console.WriteLine($"Customer1: First Name: {customer1.FirstName} and Age: {customer1.Age}\n\n\n");
        Console.WriteLine($"Customer2: First Name: {customer2.FirstName} and Age: {customer2.Age}\n\n\n");
        Console.WriteLine($"i1: {i1} , i2: {i2}");



        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void StaticTest()
    {
        Customer frodo = new Customer
        {
            FirstName = "Frodo"
        };
        Customer.InstanceCount += 1;

        Customer bilbo = new Customer
        {
            FirstName = "Bilbo"
        };
        Customer.InstanceCount += 1;

        Customer sarah = new Customer
        {
            FirstName = "Sarah"
        };
        Customer.InstanceCount += 1;

        Assert.Equal(3, Customer.InstanceCount);
    }
}
