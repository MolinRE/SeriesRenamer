namespace SeriesRenamer.Models;

// TODO: Придумать имя получше
public class MyShowsShow
{
    public string Title { get; init; }
    
    public List<MyShowsEpisode> Episodes { get; init; }
}