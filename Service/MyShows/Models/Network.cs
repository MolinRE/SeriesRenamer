using System.Text.Json.Serialization;

namespace SeriesRenamer.Service.MyShows.Models;

#pragma warning disable CS8618
public class Network
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("country")]
    public string Country { get; set; }
}