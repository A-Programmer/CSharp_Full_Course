using ACM.Common;

namespace ACM.BL;

public class OrderController
{
    private CustomerRepository customerRepository { get; set; }
    private OrderRepository orderRepository { get; set; }
    private InventoryRepository inventoryRepository { get; set; }
    private EmailLibrary emailLibrary { get; set; }

    public OrderController()
    {
        customerRepository = new();
        this.orderRepository = new();
        this.inventoryRepository = new();
        this.emailLibrary = new();
    }


    public void PlaceOrder(Customer customer,
                            Order order,
                            Payment payment,
                            bool allowSplitOrders,
                            bool emailReceipt)
    {
        customerRepository.Add(customer);

        orderRepository.Add(order);

        inventoryRepository.OrderItems(order, allowSplitOrders);

        payment.Process();

        if (emailReceipt)
        {
            customer.ValidayeEmail();
            customerRepository.Update();

            emailLibrary.SendEmail(customer.EmailAddress,
                                    "Here is your receipt");
        }

    }
}
