using HtmlAgilityPack;

namespace SeriesRenamer;

public static class Extensions
{
    public static string GetText(this HtmlNode node)
    {
        return node.InnerText.Trim();
    }
    
    public static int GetInt(this HtmlNode node)
    {
        return int.Parse(node.InnerText.Trim());
    }
}