using CacheClient;
using SeriesRenamer;
using SeriesRenamer.Helpers;
using SeriesRenamer.Service;

var options = CommandLine.Parser.Default.ParseArguments<AppOptions>(args).Value;

var client = new HttpCacheClient(Environment.GetEnvironmentVariable("CACHE_DIR")!);

var contentDir = Input.AskContentDir();
var seriesUrl = Input.AskSeriesUrl();
if (int.TryParse(seriesUrl, out var showId))
{
    seriesUrl = $"https://myshows.me/view/{showId}/";
}

var request = await client.GetAsync(seriesUrl);
var myShowsParser = new MyShowsParser(await request.Content.ReadAsStringAsync());
var episodes = myShowsParser.ParseEpisodes();
var seasons = episodes.GroupBy(p => p.SeasonNumber).ToArray();
var title = myShowsParser.ParseTitle();

var total = Directory.GetFiles(contentDir).Length;
var count = 0;
foreach (var info in FileParser.GetEpisodeFiles(contentDir))
{
    var name = FileParser.GetTitleName(episodes, info);

    if (options.DryRun)
    {
        Console.WriteLine(name);
    }
    else
    {
        File.Move(info.FileName, Path.Combine(contentDir, name));
        count++;
    }
}

Console.WriteLine($"Сериал: {title}");
Console.WriteLine($"Всего файлов: {total}");
Console.WriteLine($"Переименовано: {count}");

Input.Exit();