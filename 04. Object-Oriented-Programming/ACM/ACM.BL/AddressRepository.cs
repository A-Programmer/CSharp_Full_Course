
namespace ACM.BL;

public class AddressRepository
{
    public Address Retrive(int addressId)
    {
        Address address = new(addressId);

        if(addressId == 1)
        {
            address.AddressType = 1;
            address.StreetLine1 = "Street 1";
            address.StreetLine2 = "Street 2";
            address.City = "Gonbade Kavous";
            address.State = "Golestan";
            address.Country = "Iran";
            address.PostalCode = "123456789";
        }
        return address;
    }

    public IEnumerable<Address> RetriveByCustomerId(int customerId)
    {
        List<Address> addressList = new(1);
        Address address = new()
        {
            AddressType = 1,
            StreetLine1 = "Street 1",
            StreetLine2 = "Street 2",
            City = "Gonbade Kavous",
            State = "Golestan",
            Country = "Iran",
            PostalCode = "123456789"
        };
        addressList.Add(address);

        address = new(2)
        {
            AddressType = 2,
            StreetLine1 = "Street 3",
            StreetLine2 = "Street 4",
            City = "Gonbade Kavous",
            State = "Golestan",
            Country = "Iran",
            PostalCode = "987654321"
        };
        addressList.Add(address);

        return addressList;
    }

    public bool Save(Address address)
    {
        return true;
    }
}