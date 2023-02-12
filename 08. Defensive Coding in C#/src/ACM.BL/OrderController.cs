using System.Diagnostics;
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
        this.customerRepository = new();
        this.orderRepository = new();
        this.inventoryRepository = new();
        this.emailLibrary = new();
    }


    public OperationResult PlaceOrder(Customer customer,
                            Order order,
                            Payment payment,
                            bool allowSplitOrders,
                            bool emailReceipt)
    {
        Debug.Assert(customerRepository != null, "Missing customer repository");
        Debug.Assert(orderRepository != null, "Missing order repository");
        Debug.Assert(inventoryRepository != null, "Missing inventory repository");
        Debug.Assert(emailLibrary != null, "Missing email library");

        if (customer == null) throw new ArgumentException("Customer instance is null");
        if (order == null) throw new ArgumentException("Order instance is null");
        if (payment == null) throw new ArgumentException("Payment instance is null");

        OperationResult op = new();
        
        customerRepository.Add(customer);

        orderRepository.Add(order);

        inventoryRepository.OrderItems(order, allowSplitOrders);

        payment.ProcessPayment();

        if (emailReceipt)
        {
            OperationResult result = customer.ValidayeEmail();
            if (result.Success)
            {
                customerRepository.Update();

                emailLibrary.SendEmail(customer.EmailAddress,
                                        "Here is your receipt");
            }
            else
            {
                if (result.MessagesList.Any())
                {
                    foreach (var message in result.MessagesList)
                    {
                        op.AddMessage(message);
                    }
                }
            }
        }

        return op;

    }
}
