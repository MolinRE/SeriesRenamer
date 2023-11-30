namespace SeriesRenamer;

public class Input
{
    public static string? ReadLine(string? s = null)
    {
        if (s == null)
        {
            return Console.ReadLine();
        }
        
        Console.WriteLine(s);
        return s;
    }
}