using System.Text.RegularExpressions;
using Diacritics.Extensions;
using StringSanitizer.StringSanitizer;
using StringSanitizer.StringSanitizer.Enums;
using StringToUrl.Enum;
using StringToUrl.Model;

namespace StringToUrl.Helpers;

public static class ConversionHelper
{
    public static string RemoveNonAlphanumericCharacters(string input)
    {
        return input.SanitizeNonAlphanumeric(SanitizeSpaces.False);
    }

    public static string ChangeCase(string input, StringCase caseOption)
    {
        return caseOption == StringCase.LOWER ? input.ToLower() : input.ToUpper();
    }

    public static string ReplaceSpaces(string input, UrlOptions options)
    {
        var url = Regex.Replace(input, "( )", options.SpaceReplacementCharacter);
        return Regex.Replace(url, @"\-+","-");
    }

    public static string RemoveDiacritics(string input)
    {
        return input.RemoveDiacritics();
    }

    public static string TrimString(string input, UrlOptions options)
    {
        var length = options.MaxLength > input.Length ? input.Length : options.MaxLength;

        var trimmedString = input.Substring(0, length);

        if (trimmedString.Substring(trimmedString.Length-1) == options.SpaceReplacementCharacter)
        {
            return trimmedString.Remove(trimmedString.Length - 1, 1);
        }

        return trimmedString;
    }
}