namespace ACM.Common;
public static class StringHandler
{
    public static string InsertSpaces(this string source)
    {
        string result = string.Empty;
        if (!string.IsNullOrWhiteSpace(source))
        {
            foreach (char letter in source)
            {
                if (char.IsUpper(letter))
                {
                    result = result.Trim();
                    result += " ";
                }
                result += letter;
            }
        }
        result = result.Trim();
        return result;
    }
}
