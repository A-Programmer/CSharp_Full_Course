namespace ACM.BL;

public class Customer
{
    public int CustomerId { get; set; }
    public string EmailAddress { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public decimal CalculatePercentOfGoalSteps(decimal stepGoal, decimal todaysSteps)
    {
        try
        {
            if(stepGoal <= 0)
            {
                throw new ArgumentException("Step Goal value should be greater that 0", nameof(stepGoal));
            }
            if(todaysSteps <= 0)
            {
                throw new ArgumentException("Today Goal value should be greater that 0", nameof(todaysSteps));
            }
        }
        catch(ArgumentException ex)
        {
            Console.WriteLine($"Your entry was not valid: {ex.Message}");
        }
        
        return Math.Round(todaysSteps / stepGoal * 100, 2);
    }

    public OperationResult ValidayeEmail()
    {
        OperationResult result = new();
        
        if(string.IsNullOrWhiteSpace(this.EmailAddress))
        {
            result.Success = false;
            result.AddMessage("Email address is null");
            throw new ArgumentException("Email address is null");
        }
        else
        {
            // Send email
        }
        return result;
    }
}