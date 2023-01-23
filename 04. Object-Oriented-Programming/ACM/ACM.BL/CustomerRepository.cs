namespace ACM.BL;

public class CustomerRepository
{
    /// <summary>
    /// Retrives one customer.
    /// </summary>
    public Customer Retrive(int customerId)
    {
        Customer customer = new Customer(customerId);

        if (customerId == 1)
        {
            customer.EmailAddress = "MrSadin@Gmail.Com";
            customer.FirstName = "Kamran";
            customer.LastName = "Sadin";
        }
        return customer;
    }

    /// <summary>
    /// Saves the current customer
    /// </summary>
    public bool Save(Customer customer)
    {
        return true;
    }
}