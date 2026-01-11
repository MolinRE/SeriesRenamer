using SeriesRenamer.Models;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace SeriesRenamer.Service.MyShows;

public class MyShowsClient
{
    public async Task<MyShowsShow> GetById(int showId)
    {
        using var client = new HttpClient();
        using var request = new HttpRequestMessage(HttpMethod.Post, "https://api.myshows.me/v2/rpc/");
        var content = JsonContent.Create(new
            {
                jsonrpc = "2.0",
                method = "shows.GetById",
                @params = new {
                    showId = showId,
                    withEpisodes = true
                },
            id = 1
        });
        content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
        request.Content = content;

        var response = await client.SendAsync(request);
        
        var str = await response.Content.ReadAsByteArrayAsync();
        var root = JsonSerializer.Deserialize<Root>(str)!;

        return new MyShowsShow()
        {
            Title = root.Result.Title,
            Episodes = root.Result.Episodes.Select(s => new MyShowsEpisode()
            {
                Aired = DateOnly.FromDateTime(DateTime.Parse(s.AirDate)),
                EpisodeNumber = s.EpisodeNumber,
                EpisodeTitle = s.Title,
                SeasonNumber = s.SeasonNumber
            }).ToList()
        };
    }
}