using HtmlAgilityPack;
using SeriesRenamer.Helpers;
using SeriesRenamer.Models;

namespace SeriesRenamer.Service;

public class MyShowsParser
{
    private readonly HtmlDocument _htmlDocument = new();
    
    public MyShowsParser(string html)
    {
        _htmlDocument.LoadHtml(html);
    }
    
    public List<MyShowsEpisode> ParseEpisodes()
    {
        var result = new List<MyShowsEpisode>();
    
        var container = _htmlDocument.DocumentNode.Descendants().FirstOrDefault(p => p.Id == "episodes");
        foreach (var season in container.Elements("div").Where(p => p.HasClass("episodes-by-season__season")))
        {
            var seasonName = season.Descendants("h3").First(p => p.HasClass("title__main")).Element("a").GetText();
            var seasonNumber = int.Parse(seasonName.Split(' ')[0]);

            foreach (var episodeNode in season.Descendants("div").Where(p => p.HasClass("RowEpisodeBySeason")))
            {
                var episodeNumberText = episodeNode.Descendants("div").FirstOrDefault(p => p.HasClass("RowEpisodeBySeason__number")).GetText();
                var episodeTitle = episodeNode.Descendants("a").FirstOrDefault(p => p.HasClass("episode-col__title")).GetText();

                if (!string.IsNullOrEmpty(episodeNumberText))
                {
                    var episodeNumber = int.Parse(episodeNumberText);
            
                    // Console.WriteLine($"Сезон {seasonNumber}, эпизод {episodeNumber}: {episodeTitle}");
                    result.Add(new MyShowsEpisode
                    {
                        S = seasonNumber,
                        E = episodeNumber,
                        Title = episodeTitle
                    });
                }
            }
        }

        return result;
    }

    public string ParseTitle()
    {
        return "Lost";
    }
}