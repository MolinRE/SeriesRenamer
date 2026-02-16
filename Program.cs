using SeriesRenamer;
using SeriesRenamer.Helpers;
using SeriesRenamer.Service;
using SeriesRenamer.Service.MyShows;

var options = CommandLine.Parser.Default.ParseArguments<AppOptions>(args).Value;

var contentDir = Input.AskContentDir();
var showId = Input.AskShowId();

var client = new MyShowsClient();
var show = await client.GetById(showId);

var count = 0;
var episodesFiles = FileParser.GetEpisodeFiles(contentDir);
foreach (var episodeFile in episodesFiles)
{
    var name = FileParser.GetTitleName(show.Episodes, episodeFile);

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

Console.WriteLine($"Сериал: {show.Title} ({show.TitleOriginal})");
Console.WriteLine($"Удалось распознать: {episodesFiles.Count}");
Console.WriteLine($"Переименовано: {count}");

Input.Exit();