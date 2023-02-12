using ACM.BL;
using System.Threading;

namespace ACM.App;

public class Program
{
    public static void Main(string[] args)
    {
        System.AppDomain.CurrentDomain.UnhandledException +=
                                UnhandledExceptionTrapper;

        PlaceOrder();

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
        try
        {
            OrderController orderController = new();
            orderController.PlaceOrder(customer, order, payment,
                            allowSplitOrders, emailReceipt);
        }
        catch(ArgumentException ex)
        {
            
        }

    }


    private static void UnhandledExceptionTrapper(object sender,
                                UnhandledExceptionEventArgs e)
    {
        System.Console.WriteLine
            ($"There was a problem with this application, please contact support");
        Environment.Exit(0);
    }
}