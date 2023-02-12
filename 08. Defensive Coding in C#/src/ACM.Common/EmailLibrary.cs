namespace ACM.Common;

public class EmailLibrary
{
    public void SendEmail(string emailAddress, string v)
    {
        try
        {
            // Send an email
        }
        catch(InvalidOperationException ex)
        {
            // log
            throw;
        }
    }
}
