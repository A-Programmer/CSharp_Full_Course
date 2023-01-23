namespace ACM.BL;

public class Address
{
    public Address()
    {
    }

    public Address(int addressId)
    {
        AddressId = addressId;
    }
    public int AddressId { get; set; }
    public string StreetLine1 { get; set; }
    public string StreetLine2 { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
    public int AddressType { get; set; }

    public bool Validate()
    {
        bool isValid = true;
        isValid = PostalCode is not null;

        return isValid;
    }
}

public enum AddressTypes
{
    Home,
    Work
}