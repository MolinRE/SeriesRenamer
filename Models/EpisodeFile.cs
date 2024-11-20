namespace SeriesRenamer.Models;

public class EpisodeFile
{
    public int S { get; set; }
    
    public int E { get; set; }

    public string FileName { get; set; }

    public EpisodeFile(int s, int e, string fileName)
    {
        S = s;
        E = e;
        FileName = fileName;
    }

    public override string ToString() => FileName;
}