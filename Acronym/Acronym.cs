using System;
using System.Linq;
using System.Text.RegularExpressions;

public static class Acronym
{
    public static string Abbreviate(string phrase)
    {
        if (!string.IsNullOrEmpty(phrase))
        {
            string[] items = phrase.Split(new[] { ' ', '-', '_' }, StringSplitOptions.RemoveEmptyEntries);
            string abbr = string.Empty;

            foreach (var item in items)
            {
                abbr += item[0];
            }
            return !string.IsNullOrEmpty(abbr) ? abbr.ToUpper() : phrase;
        }
        return phrase;
    }
}