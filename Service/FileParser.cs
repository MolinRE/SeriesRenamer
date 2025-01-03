﻿using System.Text;
using System.Text.RegularExpressions;
using SeriesRenamer.Models;

namespace SeriesRenamer.Service;

public class FileParser
{
    public static readonly Regex RxEpisodeInfo = new(@".+?S(\d\d)E(\d\d).+?", RegexOptions.Compiled | RegexOptions.IgnoreCase);

    public static readonly Regex RxEpisodeInfo2 = new(@".+?(\d\d)\-(\d\d).+?", RegexOptions.Compiled | RegexOptions.IgnoreCase);
    
    
    public static IEnumerable<EpisodeFile> GetEpisodeFiles(string directory)
    {
        return Directory.GetFiles(directory)
            .Where(p => RxEpisodeInfo.IsMatch(p) || RxEpisodeInfo2.IsMatch(p))
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
        else
        {
            m = RxEpisodeInfo2.Match(fileName);
            if (m.Success)
            {
                return new EpisodeFile(int.Parse(m.Groups[1].Value), int.Parse(m.Groups[2].Value), fileName);
            }
        }

        return null;
    }

    public static string GetTitleName(List<MyShowsEpisode> episodes, EpisodeFile episodeFile)
    {
        var ext = Path.GetExtension(episodeFile.FileName);
        foreach (var ep in episodes)
        {
            if (ep.EpisodeNumber == episodeFile.E && ep.SeasonNumber == episodeFile.S)
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