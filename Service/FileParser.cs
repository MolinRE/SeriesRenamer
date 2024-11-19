using System.Text;
using System.Text.RegularExpressions;
using SeriesRenamer.Models;

namespace SeriesRenamer.Service;

public class FileParser
{
    public static readonly Regex RxEpisodeInfo = new(@".+?S(\d\d)E(\d\d).+?", RegexOptions.Compiled | RegexOptions.IgnoreCase);

    public static IEnumerable<EpisodeFile> GetEpisodeFiles(string directory)
    {
        return Directory.GetFiles(directory)
            .Where(p => RxEpisodeInfo.IsMatch(p))
            .OrderBy(s => s)
            .Select(ParseFileName);
    }
    
    public static EpisodeFile ParseFileName(string fileName)
    {
        var m = RxEpisodeInfo.Match(fileName);
        if (m.Success)
        {
            return new EpisodeFile(int.Parse(m.Groups[1].Value), int.Parse(m.Groups[2].Value), fileName);
        }

        return null;
    }

    public static string GetTitleName(List<MyShowsEpisode> eps, EpisodeFile fileEp)
    {
        var ext = Path.GetExtension(fileEp.FileName);
        foreach (var e in eps)
        {
            if (e.EpisodeNumber == fileEp.E && e.SeasonNumber == fileEp.S)
            {
                return $"S{e.SeasonNumber:##}E{e.EpisodeNumber:##}. {CleanTitle(e.EpisodeTitle)}{ext}";
            }
        }

        string CleanTitle(string str)
        {
            var sb = new StringBuilder();
            foreach (var ch in str)
            {
                sb.Append(Path.GetInvalidFileNameChars().Contains(ch) ? '_' : ch);
            }

            return sb.Length == 0 ? str : sb.ToString();
        }

        return null;
    }
}