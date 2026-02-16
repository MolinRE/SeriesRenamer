using System.Text.Json.Serialization;

namespace SeriesRenamer.Service.MyShows.Models;

public class GetByIdResponse
{
    [JsonPropertyName("jsonrpc")]
    public string Jsonrpc { get; set; }

    [JsonPropertyName("result")]
    public GetByIdResult Result { get; set; }

    [JsonPropertyName("id")]
    public int Id { get; set; }
}