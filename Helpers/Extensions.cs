﻿using HtmlAgilityPack;
using System.Net;

namespace SeriesRenamer.Helpers;

public static class Extensions
{
    public static string GetText(this HtmlNode node)
    {
        return WebUtility.HtmlDecode(node.InnerText.Trim());
    }
    
    public static int GetInt(this HtmlNode node)
    {
        return int.Parse(node.InnerText.Trim());
    }
}