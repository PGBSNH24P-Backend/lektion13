namespace ProgramForTest;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}

public class StringUtility
{
    public static int CalculateNewLines(string s)
    {
        int count = 0;
        foreach (var c in s)
        {
            if (c == '\n')
            {
                count++;
            }
        }
        return count;
    }
}
