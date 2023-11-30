using SeriesRenamer.Helpers;
using SeriesRenamer.Service;

var client = new HttpClient();

var contentDir = Input.AskContentDir();
var seriesUrl = Input.AskSeriesUrl();

var myShowsParser = new MyShowsParser(await client.GetStringAsync(seriesUrl));
var episodes = myShowsParser.ParseEpisodes();
var title = myShowsParser.ParseTitle();

var total = Directory.GetFiles(contentDir).Length;
var count = 0;
foreach (var info in FileParser.GetEpisodeFiles(contentDir))
{
    var name = FileParser.GetTitleName(episodes, info);
    Debug(Path.GetFileName(info.FileName), name);
    
    File.Move(info.FileName, Path.Combine(contentDir, name));
    count++;
}

Console.WriteLine($"Сериал: {title}");
Console.WriteLine($"Всего файлов: {total}");
Console.WriteLine($"Переменовано: {count}");

void Debug(string oldName, string newName)
{
    #if DEBUG
    Console.WriteLine($"Старое название: {oldName}");
    Console.WriteLine($"Новое название: {newName}");
    Console.WriteLine("Продолжить?");
    Console.ReadLine();
    #endif
}