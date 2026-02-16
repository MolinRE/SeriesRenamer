using System.Text.Json.Serialization;

namespace SeriesRenamer.Service.MyShows.Models;

public class Episode
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("showId")]
    public int ShowId { get; set; }

    [JsonPropertyName("seasonNumber")]
    public int SeasonNumber { get; set; }

    [JsonPropertyName("episodeNumber")]
    public int EpisodeNumber { get; set; }

    [JsonPropertyName("airDate")]
    public string AirDate { get; set; }

    [JsonPropertyName("airDateUTC")]
    public string AirDateUTC { get; set; }

    [JsonPropertyName("images")]
    public List<string> Images { get; set; }

    [JsonPropertyName("image")]
    public string Image { get; set; }

    [JsonPropertyName("shortName")]
    public string ShortName { get; set; }

    [JsonPropertyName("commentsCount")]
    public int? CommentsCount { get; set; }

    [JsonPropertyName("isSpecial")]
    public bool IsSpecial { get; set; }
}