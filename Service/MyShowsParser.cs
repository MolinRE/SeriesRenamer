using HtmlAgilityPack;
using SeriesRenamer.Helpers;
using SeriesRenamer.Models;
using System.Net;

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
        foreach (var season in container.Elements("div").Where(p => p.HasClass("EpisodesBySeason__season")))
        {
            var seasonName = season.Descendants("h3").First(p => p.HasClass("title__main-text")).Element("a").GetText();
            var seasonNumber = int.Parse(seasonName.Split(' ')[0]);

            foreach (var episodeNode in season.Descendants("div").Where(p => p.HasClass("RowEpisodeBySeason")))
            {
                var episodeNumberText = episodeNode.Descendants("div").FirstOrDefault(p => p.HasClass("RowEpisodeBySeason__number")).GetText();
                var episodeTitle = episodeNode.Descendants("a").FirstOrDefault(p => p.HasClass("episode-col__title")).GetText();

                if (!string.IsNullOrEmpty(episodeNumberText))
                {
                    var episodeNumber = int.Parse(episodeNumberText);
            
                    result.Add(new MyShowsEpisode
                    {
                        SeasonNumber = seasonNumber,
                        EpisodeNumber = episodeNumber,
                        EpisodeTitle = episodeTitle
                    });
                }
            }
        }

        return result;
    }

    public string ParseTitle()
    {
        var title = string.Empty;
        var originalTitle = string.Empty;
        
        var titleMainText = _htmlDocument.DocumentNode
            .Descendants("h1")
            .FirstOrDefault(p => p.HasClass("title__main-text"));

        if (titleMainText != null)
        {
            title = WebUtility.HtmlDecode(titleMainText.InnerText.Trim());
        }

        var showDetailsOriginal = _htmlDocument.DocumentNode
            .Descendants("div")
            .FirstOrDefault(p => p.HasClass("ShowDetails-original"));

        if (showDetailsOriginal != null)
        {
            originalTitle = WebUtility.HtmlDecode(showDetailsOriginal.InnerText.Trim());
        }

        return $"{title} ({originalTitle})";
    }
}