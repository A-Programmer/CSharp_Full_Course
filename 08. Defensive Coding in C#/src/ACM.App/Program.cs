using ACM.BL;

namespace ACM.App;

public class Program
{
    public static void Main(string[] args)
    {
        // PlaceOrder();

        stepsInput:
        System.Console.WriteLine("Step Goal for Today:");
        string stepsInput = Console.ReadLine();
        if(!decimal.TryParse(stepsInput, out var stepGoal))
        {
            System.Console.WriteLine("Please enter a decimal value.");
            goto stepsInput;
        }
        todaysSteps:
        System.Console.WriteLine("Number of Steps Today:");
        string todaysStepsInput = Console.ReadLine();
        if(!decimal.TryParse(todaysStepsInput, out var todaysSteps))
        {
            System.Console.WriteLine("Please enter a decimal value.");
            goto todaysSteps;
        }
        Customer customer = new();
        Decimal result = customer.CalculatePercentOfGoalSteps(stepGoal, todaysSteps);
        Console.WriteLine($"You reached {result}% of your goal!");
    }

    private static void PlaceOrder()
    {
        Customer customer = new();

        Order order = new();

        bool allowSplitOrders = true;
        bool emailReceipt = true;
        
        Payment payment = new();

        OrderController orderController = new();
        orderController.PlaceOrder(customer, order, payment, allowSplitOrders, emailReceipt);

    }
}