namespace Introduction;

class Program
{
    static void Main(string[] args)
    {
        // If you are using windows the path should be something like: c:\Winsows
        string path = "/Users/sadin/Desktop";
        ShowLargestFilesWithoutLinq(path);
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
}

public class FileInfoComparer : IComparer<FileInfo>
{
    public int Compare(FileInfo? x, FileInfo? y)
    {
        return y.Length.CompareTo(x.Length);
    }
}