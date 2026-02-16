namespace SeriesRenamer.Helpers;

public static class Input
{
    public static string AskContentDir()
    {
        const string promt = "Введите путь к папке с сериями: ";
        Console.Write(promt);
        var input = Console.ReadLine();
        while (!Directory.Exists(input))
        {
            Console.WriteLine("Папка не найдена");
            Console.Write(promt);
            input = Console.ReadLine(); 
        }
        Console.WriteLine($"Найдено файлов: {Directory.GetFiles(input).Length}");
        return input;
    }

    public static int AskShowId()
    {
        const string promt = "Введите адрес страницы или идентификатор сериала на MyShows: ";
        while (true)
        {
            Console.Write(promt);
            var input = Console.ReadLine();
            if (input != null && input.StartsWith("http"))
            {
                input = input.Trim('/');
                input = input.Substring(input.LastIndexOf('/') + 1);
            }

            if (int.TryParse(input, out var showId))
            {
                return showId;
            }
        }
    }

    public static void Exit()
    {
        Console.WriteLine("Для выхода нажмите любую клавишу");
        Console.ReadKey();
    }
}