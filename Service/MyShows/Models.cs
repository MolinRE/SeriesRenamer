using System.Text.Json.Serialization;

namespace SeriesRenamer.Service.MyShows;

// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
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
        public int CommentsCount { get; set; }

        [JsonPropertyName("isSpecial")]
        public bool IsSpecial { get; set; }
    }

    public class Network
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }
    }

    public class Result
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("titleOriginal")]
        public string TitleOriginal { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("totalSeasons")]
        public int TotalSeasons { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("countryTitle")]
        public string CountryTitle { get; set; }

        [JsonPropertyName("started")]
        public string Started { get; set; }

        [JsonPropertyName("ended")]
        public string Ended { get; set; }

        [JsonPropertyName("year")]
        public int Year { get; set; }

        [JsonPropertyName("kinopoiskId")]
        public int KinopoiskId { get; set; }

        [JsonPropertyName("kinopoiskRating")]
        public double KinopoiskRating { get; set; }

        [JsonPropertyName("kinopoiskVoted")]
        public int KinopoiskVoted { get; set; }

        [JsonPropertyName("kinopoiskUrl")]
        public string KinopoiskUrl { get; set; }

        [JsonPropertyName("tvrageId")]
        public object TvrageId { get; set; }

        [JsonPropertyName("imdbId")]
        public int ImdbId { get; set; }

        [JsonPropertyName("imdbRating")]
        public double ImdbRating { get; set; }

        [JsonPropertyName("imdbVoted")]
        public int ImdbVoted { get; set; }

        [JsonPropertyName("imdbUrl")]
        public string ImdbUrl { get; set; }

        [JsonPropertyName("watching")]
        public int Watching { get; set; }

        [JsonPropertyName("watchingTotal")]
        public int WatchingTotal { get; set; }

        [JsonPropertyName("voted")]
        public int Voted { get; set; }

        [JsonPropertyName("rating")]
        public double Rating { get; set; }

        [JsonPropertyName("runtime")]
        public int Runtime { get; set; }

        [JsonPropertyName("runtimeTotal")]
        public string RuntimeTotal { get; set; }

        [JsonPropertyName("images")]
        public List<string> Images { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }

        [JsonPropertyName("genreIds")]
        public List<int> GenreIds { get; set; }

        [JsonPropertyName("network")]
        public Network Network { get; set; }

        [JsonPropertyName("episodes")]
        public List<Episode> Episodes { get; set; }

        [JsonPropertyName("onlineLinks")]
        public List<object> OnlineLinks { get; set; }

        [JsonPropertyName("onlineLinkExclusive")]
        public object OnlineLinkExclusive { get; set; }
    }

    public class Root
    {
        [JsonPropertyName("jsonrpc")]
        public string Jsonrpc { get; set; }

        [JsonPropertyName("result")]
        public Result Result { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }
    }

