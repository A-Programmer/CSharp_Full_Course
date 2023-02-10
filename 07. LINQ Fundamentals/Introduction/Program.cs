namespace Introduction;

class Program
{
    static void Main(string[] args)
    {
        // If you are using windows the path should be something like: c:\Winsows
        string path = "/Users/sadin/Desktop";
        ShowLargestFilesWithoutLinq(path);
        Console.WriteLine("********************");
        ShowLargestFilesWithLinq(path);
    }

    private static void ShowLargestFilesWithoutLinq(string path)
    {
        DirectoryInfo directory = new(path);
        FileInfo[] files = directory.GetFiles();
        Array.Sort(files, new FileInfoComparer());

        for (int i = 0; i < 5; i++)
        {
            FileInfo file = files[i];
            Console.WriteLine($"{file.Name, -40} : {file.Length, 10:N0}");
        }
    }

    private static void ShowLargestFilesWithLinq(string path)
    {
        var query = from file in new DirectoryInfo(path).GetFiles()
            orderby file.Length descending
            select file;
        foreach (FileInfo file in query.Take(5))
        {
            Console.WriteLine($"{file.Name, -40} : {file.Length, 10:N0}");
        }
    }
}

public class FileInfoComparer : IComparer<FileInfo>
{
    public int Compare(FileInfo? x, FileInfo? y)
    {
        return y.Length.CompareTo(x.Length);
    }
}