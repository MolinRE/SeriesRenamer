using System.Text;
using System.Text.RegularExpressions;
using SeriesRenamer.Models;

namespace SeriesRenamer.Service;

public class FileParser
{
    public static readonly Regex[] RxEpisodeInfos = new[]
    {
        new Regex(@".+?S(\d\d)E(\d\d).+?", RegexOptions.Compiled | RegexOptions.IgnoreCase),
        new Regex(@".+?(\d\d)\-(\d\d).+?", RegexOptions.Compiled | RegexOptions.IgnoreCase),
        new Regex(@".+?\-\s?(\d\d).+?", RegexOptions.Compiled | RegexOptions.IgnoreCase) // anime format
    };
    
    public static IEnumerable<EpisodeFile> GetEpisodeFiles(string directory)
    {
        var di = new DirectoryInfo(directory);
        var files = di.GetFiles().OrderBy(p => p.Name).ToArray();
        var result = new List<EpisodeFile>(files.Length);
        foreach (var fileInfo in files)
        {
            foreach (var regex in RxEpisodeInfos)
            {
                if (regex.IsMatch(fileInfo.Name))
                {
                    result.Add(ParseFileName(regex, fileInfo));
                }
            }
        }

        return result;
    }
    
    public static EpisodeFile ParseFileName(Regex regex, FileInfo file)
    {
        var fileName = file.FullName;
        var m = regex.Match(file.Name);
        if (m.Groups.Count == 3)
        {
            return new EpisodeFile(int.Parse(m.Groups[1].Value), int.Parse(m.Groups[2].Value), fileName);
        }
            
        return new EpisodeFile(1, int.Parse(m.Groups[1].Value), fileName);
    }

    public static string GetTitleName(List<MyShowsEpisode> episodes, EpisodeFile episodeFile)
    {
        var ext = Path.GetExtension(episodeFile.FileName);
        foreach (var ep in episodes)
        {
            if (ep.EpisodeNumber == episodeFile.EpisodeNumber && ep.SeasonNumber == episodeFile.SeasonNumber)
            {
                return $"S{ep.SeasonNumber:##}E{ep.EpisodeNumber:##}. {CleanTitle(ep.EpisodeTitle)}{ext}";
            }
        }

        throw new ArgumentException($"В списке эпизодов нет указанного файла ({episodeFile})", nameof(episodeFile));

        string CleanTitle(string str)
        {
            var sb = new StringBuilder();
            foreach (var ch in str)
            {
                sb.Append(Path.GetInvalidFileNameChars().Contains(ch) ? '_' : ch);
            }

            return sb.Length == 0 ? str : sb.ToString();
        }
    }
}