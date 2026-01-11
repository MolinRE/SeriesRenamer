namespace SeriesRenamer.Models;

public class EpisodeFile
{
    public int SeasonNumber { get; set; }
    
    public int EpisodeNumber { get; set; }

    public string FileName { get; set; }

    public EpisodeFile(int seasonNumber, int episodeNumber, string fileName)
    {
        SeasonNumber = seasonNumber;
        EpisodeNumber = episodeNumber;
        FileName = fileName;
    }

    public override string ToString() => FileName;
}