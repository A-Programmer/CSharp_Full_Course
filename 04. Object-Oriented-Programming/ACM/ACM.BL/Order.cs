namespace ACM.BL;

public class Order
{
    public Order() : this(0)
    {
        
    }

    public Order(int orderId)
    {
        OrderId = orderId;
        OrderItems = new();
    }

    public int CustomerId { get; set; }
    public DateTimeOffset? OrderDate { get; set; }
    public int OrderId { get; private set; }
    public List<OrderItem> OrderItems { get; set; }
    public int ShippingAddressId { get; set; }

    public bool Validate()
    {
        bool isValid = true;

        isValid = OrderDate is not null;

        return isValid;
    }
    public override string ToString() => $"{OrderDate.Value.Date} ({OrderId})";
}