namespace SeriesRenamer.Models;

/// <summary>
/// Информация об эпизоде на сайте MyShows
/// </summary>
public class MyShowsEpisode
{
    /// <summary>
    /// Номер сезона
    /// </summary>
    public int SeasonNumber { get; set; }
    
    /// <summary>
    /// Номер эпизода
    /// </summary>
    public int EpisodeNumber { get; set; }

    /// <summary>
    /// Название эпизода
    /// </summary>
    public string EpisodeTitle { get; set; }
    
    /// <summary>
    /// Дата выхода эпизода
    /// </summary>
    public DateOnly? Aired { get; set; }

    public override string ToString()
    {
        return $"S{SeasonNumber:##}E{EpisodeNumber:##}. {EpisodeTitle}";
    }
}