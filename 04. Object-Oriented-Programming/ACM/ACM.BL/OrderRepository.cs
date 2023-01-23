namespace ACM.BL;

public class OrderRepository
{
    /// <summary>
    /// Retrives one Product.
    /// </summary>
    public Order Retrive(int orderId)
    {
        Order order = new Order(orderId);

        if (orderId == 10)
        {
            order.OrderDate = new(DateTime.Now.Year, 4, 14, 10, 00, 00,
                new TimeSpan(7, 0, 0));
        }
        return order;
    }

    /// <summary>
    /// Saves the current Order
    /// </summary>
    public bool Save(Order order)
    {
        return true;
    }
}