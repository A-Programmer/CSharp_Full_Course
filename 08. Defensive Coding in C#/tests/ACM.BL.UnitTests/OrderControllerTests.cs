namespace ACM.BL.UnitTests;

public class OrderControllerTests
{
    [Fact]
    public void PlaceOrder_InvalidEmail_ShouldThrowException()
    {
        OrderController orderController = new();
        Customer customer = new();
        Order order = new();
        Payment payment = new() { PaymentType = PaymentType.CreditCard };

        Action op = () =>
        {
            orderController.PlaceOrder(customer, order, payment,
                                            allowSplitOrders: true, emailReceipt: true);
        };

        Assert.Throws<ArgumentException>(op);
    }

    [Fact]
    public void PlaceOrder_CustomerIsNull_ShouldThrowException()
    {
        OrderController orderController = new();
        Customer customer = null;
        Order order = new();
        Payment payment = new() { PaymentType = PaymentType.CreditCard };

        Action op = () =>
        {
            orderController.PlaceOrder(customer, order, payment,
                                            allowSplitOrders: true, emailReceipt: true);
        };

        Assert.Throws<ArgumentException>(op);
    }

    [Fact]
    public void PlaceOrder_OrderIsNull_ShouldThrowException()
    {
        OrderController orderController = new();
        Customer customer = new();
        Order order = null;
        Payment payment = new() { PaymentType = PaymentType.CreditCard };

        Action op = () =>
        {
            orderController.PlaceOrder(customer, order, payment,
                                            allowSplitOrders: true, emailReceipt: true);
        };

        Assert.Throws<ArgumentException>(op);
    }

    [Fact]
    public void PlaceOrder_PaymentIsNull_ShouldThrowException()
    {
        OrderController orderController = new();
        Customer customer = new();
        Order order = new();
        Payment payment = null;

        Action op = () =>
        {
            orderController.PlaceOrder(customer, order, payment,
                                            allowSplitOrders: true, emailReceipt: true);
        };

        Assert.Throws<ArgumentException>(op);
    }
}
