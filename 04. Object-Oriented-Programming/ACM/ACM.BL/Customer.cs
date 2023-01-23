namespace ACM.BL;

public class Customer
{
    public Customer()
        : this(0)
    {
        
    }

    public Customer(int customerId)
    {
        CustomerId = customerId;
        AddessList = new();
    }
    public List<Address> AddessList { get; set; }
    public int CustomerId { get; private set; }
    public int CustomerType { get; set; }
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

    /// <summary>
    /// Validates the customer data.
    /// </summary>
    public bool Validate()
    {
        bool isValid = true;
        if (string.IsNullOrWhiteSpace(LastName)) isValid = false;
        if (string.IsNullOrWhiteSpace(EmailAddress)) isValid = false;
        
        return isValid;
    }
}