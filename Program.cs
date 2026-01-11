using SeriesRenamer;
using SeriesRenamer.Helpers;
using SeriesRenamer.Service;
using SeriesRenamer.Service.MyShows;

var options = CommandLine.Parser.Default.ParseArguments<AppOptions>(args).Value;

var contentDir = Input.AskContentDir();
var showId = Input.AskSeriesUrl();
if (showId.StartsWith("https"))
{
    showId = showId.Trim('/');
    showId = showId.Substring(showId.LastIndexOf('/') + 1);
}

var client = new MyShowsClient();
var show = await client.GetById(int.Parse(showId));
var episodes = show.Episodes;
var title = show.Title;

var total = Directory.GetFiles(contentDir).Length;
var count = 0;
var episodesFiles = FileParser.GetEpisodeFiles(contentDir);
foreach (var episodeFile in episodesFiles)
{
    var name = FileParser.GetTitleName(episodes, episodeFile);

    if (options.DryRun)
    {
        Console.WriteLine(name);
    }
    else
    {
        var outputDir = string.IsNullOrEmpty(options.DestinationFolder) ? contentDir : options.DestinationFolder;
        File.Move(episodeFile.FileName, Path.Combine(outputDir, name));
        count++;
    }
}

Console.WriteLine($"Сериал: {title}");
Console.WriteLine($"Всего файлов: {total}");
Console.WriteLine($"Переименовано: {count}");

Input.Exit();