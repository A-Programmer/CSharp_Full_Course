namespace ACM.BL;

public class OrderItem
{
    public OrderItem()
    {
        
    }
    public OrderItem(int orderItemId)
    {
        orderItemId = orderItemId;
    }

    public int OrderItemId { get; private set; }
    public int ProductId { get; set; }
    public decimal? PurchasePrice { get; set; }
    public int Quantity { get; set; }
    
    public OrderItem Retrive(int orderId)
    {
        return new OrderItem();
    }

    public bool Save()
    {
        return true;
    }

    public bool Validate()
    {
        bool isValid = true;

        isValid = Quantity > 0;
        isValid = ProductId > 1;
        isValid = PurchasePrice is not null;
        
        return isValid;
    }
}