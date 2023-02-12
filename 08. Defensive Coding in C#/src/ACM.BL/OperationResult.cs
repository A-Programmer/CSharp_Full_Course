namespace ACM.BL;

public class OperationResult
{
    public bool Success { get; set; }
    public List<string> MessagesList { get; private set; }
    public OperationResult()
    {
        MessagesList = new();
        Success = true;
    }

    public void AddMessage(string message)
    {
        MessagesList.Add(message);
    }
}
