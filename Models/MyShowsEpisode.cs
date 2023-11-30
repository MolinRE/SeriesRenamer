namespace SeriesRenamer.Models;

/// <summary>
/// Информация об эпизоде на сайте MyShows
/// </summary>
public class MyShowsEpisode
{
    /// <summary>
    /// Номер сезона
    /// </summary>
    public int S { get; set; }
    
    /// <summary>
    /// Номер эпизода
    /// </summary>
    public int E { get; set; }

    /// <summary>
    /// Название эпизода
    /// </summary>
    public string Title { get; set; }
    
    /// <summary>
    /// Дата выхода эпизода
    /// </summary>
    public DateOnly? Aired { get; set; }
}