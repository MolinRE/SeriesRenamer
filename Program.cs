using System.Text;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using SeriesRenamer;

var RxEpisodeInfo = new Regex(@".+?S(\d\d)E(\d\d).+?", RegexOptions.Compiled);

Console.WriteLine("Введите путь к папке с сериями:");
var contentDir = Console.ReadLine();

while (!Directory.Exists(contentDir))
{
    Console.WriteLine("Папка не найдена");
    Console.WriteLine("Введите путь к папке с сериями:");
    contentDir = Console.ReadLine(); 
}

Console.WriteLine($"Найдено файлов: {Directory.GetFiles(contentDir).Length}");

Console.WriteLine("Введите адрес страницы сериала на MyShows:");
var seriesUrl = Console.ReadLine();

var client = new HttpClient();

var htmlDocument = new HtmlDocument();
htmlDocument.LoadHtml(await client.GetStringAsync(seriesUrl));
List<MyShowsEpisode> episodes = ParseMyShows(htmlDocument.DocumentNode);
var title = ParseTitle(htmlDocument.DocumentNode);

int total = Directory.GetFiles(contentDir).Length;
int count = 0;
foreach (var file in Directory.GetFiles(contentDir))
{
    EpisodeFile info = ParseFileName(file);

    var name = GetTitleName(episodes, info);
    
    Console.WriteLine($"Старое название: {file}");
    Console.WriteLine($"Новое название: {Path.Combine(contentDir, name)}");
    Console.WriteLine("Продолжить? Y/N");
    var continueChar = Console.ReadLine();
    if (continueChar.ToLower() == "n")
    {
        break;
    }
    
    File.Move(file, Path.Combine(contentDir, name));
    count++;
}

Console.WriteLine($"Сериал: {title}");
Console.WriteLine($"Всего файлов: {total}");
Console.WriteLine($"Переменовано: {count}");

Console.WriteLine();

EpisodeFile ParseFileName(string fileName)
{
    var m = RxEpisodeInfo.Match(fileName);
    if (m.Success)
    {
        return new EpisodeFile(int.Parse(m.Groups[1].Value), int.Parse(m.Groups[2].Value), fileName);
    }

    return null;
}

string GetTitleName(List<MyShowsEpisode> eps, EpisodeFile fileEp)
{
    var ext = Path.GetExtension(fileEp.FileName);
    foreach (var e in eps)
    {
        if (e.E == fileEp.E && e.S == fileEp.S)
        {
            return $"S{e.S:##}E{e.E:##}. {CleanTitle(e.Title)}{ext}";
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

List<MyShowsEpisode> ParseMyShows(HtmlNode node)
{
    var result = new List<MyShowsEpisode>();
    
    var container = node.Descendants().FirstOrDefault(p => p.Id == "episodes");
    foreach (var season in container.Elements("div").Where(p => p.HasClass("episodes-by-season__season")))
    {
        var seasonName = season.Descendants("h3").First(p => p.HasClass("title__main")).Element("a").GetText();
        var seasonNumber = int.Parse(seasonName.Split(' ')[0]);

        foreach (var episodeNode in season.Descendants("div").Where(p => p.HasClass("RowEpisodeBySeason")))
        {
            var episodeNumberText = episodeNode.Descendants("div").FirstOrDefault(p => p.HasClass("RowEpisodeBySeason__number")).GetText();
            var episodeTitle = episodeNode.Descendants("a").FirstOrDefault(p => p.HasClass("episode-col__title")).GetText();

            if (!string.IsNullOrEmpty(episodeNumberText))
            {
                var episodeNumber = int.Parse(episodeNumberText);
            
                // Console.WriteLine($"Сезон {seasonNumber}, эпизод {episodeNumber}: {episodeTitle}");
                result.Add(new MyShowsEpisode
                {
                    S = seasonNumber,
                    E = episodeNumber,
                    Title = episodeTitle
                });
            }
        }
    }

    return result;
}

string ParseTitle(HtmlNode node)
{
    throw new NotImplementedException();
}

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
}

public class MyShowsEpisode
{
    public int S { get; set; }
    
    public int E { get; set; }

    public string Title { get; set; }

    public DateOnly? Aired { get; set; }
}