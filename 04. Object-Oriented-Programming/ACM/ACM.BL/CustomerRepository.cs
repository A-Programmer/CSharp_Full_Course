namespace ACM.BL;

public class CustomerRepository
{
    private AddressRepository _addressRepository;
    public CustomerRepository()
    {
        _addressRepository = new AddressRepository();
    }
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
            customer.AddessList = _addressRepository.RetriveByCustomerId(customerId).ToList();
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