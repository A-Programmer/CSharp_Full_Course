namespace ACM.BL;

public class Order
{
    public Order()
    {
        
    }

    public Order(int orderId)
    {
        OrderId = orderId;
    }

    public DateTimeOffset? OrderDate { get; set; }
    public int OrderId { get; private set; }

    public bool Validate()
    {
        bool isValid = true;

        isValid = OrderDate is not null;

        return isValid;
    }
}