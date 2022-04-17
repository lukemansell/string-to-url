using System.Text.RegularExpressions;
using Diacritics.Extensions;
using StringSanitizer.StringSanitizer;
using StringSanitizer.StringSanitizer.Enums;
using StringToUrl.Enum;
using StringToUrl.Model;

namespace StringToUrl.Service;

public static class ConversionService
{
    public static string Convert(
        string input,
        UrlOptions options)
    {
        var url = RemoveDiacritics(input);

        url = RemoveNonAlphanumericCharacters(url);
        
        url = ReplaceSpaces(url, options);
        
        if (options.Case != StringCase.UNCHANGED)
        {
            url = ChangeCase(url, options.Case);
        }

        if (options.MaxLength != 0)
        {
            url = TrimString(url, options.MaxLength);
        }

        return url;
    }

    private static string RemoveNonAlphanumericCharacters(string input)
    {
        return input.SanitizeNonAlphanumeric(SanitizeSpaces.False);
    }

    private static string ChangeCase(string input, StringCase caseOption)
    {
        return caseOption == StringCase.LOWER ? input.ToLower() : input.ToUpper();
    }

    private static string ReplaceSpaces(string input, UrlOptions options)
    {
        var url = Regex.Replace(input, "( )", options.SpaceReplacementCharacter);
        return Regex.Replace(url, @"\-+","-");
    }

    private static string RemoveDiacritics(string input)
    {
        return input.RemoveDiacritics();
    }

    private static string TrimString(string input, int maxLength)
    {
        return input.Substring(0, maxLength);
    }
}