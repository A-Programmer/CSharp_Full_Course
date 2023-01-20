namespace ACM.BL;

public class Customer
{
    public int CustomerId { get; private set; }
    public int Age { get; set; }
    public static int InstanceCount { get; set; }
    private string _lastName;
    public string LastName 
    {
        get
        {
            return _lastName;
        }
        set
        {
            _lastName = value;
        }
    }

    public string FirstName { get; set; }
    public string EmailAddress { get; set; }
    public string FullName
    {
        get
        {
            string fullName = LastName;
            if (!string.IsNullOrWhiteSpace(FirstName))
            {
                if (!string.IsNullOrWhiteSpace(fullName))
                {
                    fullName += ", ";
                }
                fullName += FirstName;
            }
            return fullName;
        }
    }

    public void Test()
    {
        var customer1 = new Customer
        {
            FirstName = "Kamran",
            Age = 34
        };

        var customer2 = customer1;

        customer2.FirstName = "Amir";
        customer2.Age = 30;

        Console.WriteLine($"Customer1: First Name: {customer1.FirstName} and Age: {customer1.Age}\n\n\n");
        Console.WriteLine($"Customer2: First Name: {customer2.FirstName} and Age: {customer2.Age}");
    }
    
}