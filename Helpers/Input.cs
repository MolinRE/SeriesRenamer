namespace SeriesRenamer.Helpers;

public static class Input
{
    /// <summary>
    /// Обертка на Console.ReadLine, которая позволяет вывести на консоль замену строки, если ручной ввод не требуется
    /// </summary>
    /// <param name="s">Строка для замены пользовательского ввода</param>
    /// <returns>Строка из ввода</returns>
    public static string? ReadLine(string? s = null)
    {
        if (s == null)
        {
            return Console.ReadLine();
        }
        
        Console.WriteLine(s);
        return s;
    }

    public static string AskContentDir()
    {
        Console.Write("Введите путь к папке с сериями:");
        var input = Input.ReadLine();
        while (!Directory.Exists(input))
        {
            Console.WriteLine("Папка не найдена");
            Console.Write("Введите путь к папке с сериями:");
            input = Input.ReadLine(); 
        }
        Console.WriteLine($"Найдено файлов: {Directory.GetFiles(input).Length}");
        return input;
    }

    public static string? AskSeriesUrl()
    {
        Console.WriteLine("Введите адрес страницы сериала на MyShows:");
        return Input.ReadLine("https://myshows.me/view/8/");
    }
}