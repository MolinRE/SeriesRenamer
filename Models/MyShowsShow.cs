namespace SeriesRenamer.Models;

// TODO: Придумать имя получше
public class MyShowsShow
{
    /// <summary>
    /// Название сериала на русском языке
    /// </summary>
    public string Title { get; init; }
    
    /// <summary>
    /// Название сериала на английском
    /// </summary>
    public string TitleOriginal { get; set; }
    
    /// <summary>
    /// Список эпизодов сериала
    /// </summary>
    public List<MyShowsEpisode> Episodes { get; init; }
}