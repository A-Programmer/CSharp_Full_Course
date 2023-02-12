namespace ACM.BL.UnitTests;

public class CustomerTests
{
    [Fact]
    public void CalculatePercentOfGoalSteps_InputIsValid_ShouldReturnCorrectResult()
    {
        Customer customer = new();
        decimal stepGoal = 5000;
        decimal stepsToday = 2000;
        decimal expected = 40M;

        decimal actual = customer.CalculatePercentOfGoalSteps(stepGoal, stepsToday);
    
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void CalculatePercentOfGoalSteps_TodaysStepsIsInvalid_ShouldThrowArgumentException()
    {
        Customer customer = new();
        decimal stepGoal = 5000;
        decimal stepsToday = 0;

        Action action = () =>
        {
            customer.CalculatePercentOfGoalSteps(stepGoal, stepsToday);
        } ;
    
        Assert.Throws<ArgumentException>(action);
    }
    
    [Fact]
    public void CalculatePercentOfGoalSteps_GoalStepsIsInvalid_ShouldThrowArgumentException()
    {
        Customer customer = new();
        decimal stepGoal = 0;
        decimal stepsToday = 2000;

        Action action = () =>
        {
            customer.CalculatePercentOfGoalSteps(stepGoal, stepsToday);
        } ;
        Assert.Throws<ArgumentException>(action);
    }
    
    [Fact]
    public void CalculatePercentOfGoalSteps_GoalStepsIsInvalid_ShouldThrowCorrectMessageException()
    {
        Customer customer = new();
        decimal stepGoal = 0;
        decimal stepsToday = 2000;
        string expected = $"Step Goal value should be greater that 0 (Parameter 'stepGoal')";

        var actual = Assert.Throws<ArgumentException>(() => customer.CalculatePercentOfGoalSteps(stepGoal, stepsToday));
        
        Assert.Equal(expected, actual.Message);
    }
}