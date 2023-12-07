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
        if (string.IsNullOrEmpty(s))
        {
            return Console.ReadLine();
        }
        
        Console.WriteLine(s);
        return s;
    }

    public static string AskContentDir()
    {
        string promt = "Введите путь к папке с сериями: ";
        Console.Write(promt);
        var input = Input.ReadLine();
        while (!Directory.Exists(input))
        {
            Console.WriteLine("Папка не найдена");
            Console.Write(promt);
            input = Input.ReadLine(); 
        }
        Console.WriteLine($"Найдено файлов: {Directory.GetFiles(input).Length}");
        return input;
    }

    public static string? AskSeriesUrl()
    {
        Console.Write("Введите адрес страницы сериала на MyShows: ");
        return Input.ReadLine();
    }

    public static void Exit()
    {
        Console.WriteLine("Для выхода нажмите любую клавишу");
        Console.ReadKey();
    }
    
}