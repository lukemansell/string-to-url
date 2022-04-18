using StringToUrl.Enum;
using StringToUrl.Helpers;
using StringToUrl.Model;

namespace StringToUrl.Service;

public static class ConversionService
{
    public static string Convert(
        string input,
        UrlOptions options)
    {
        var url = ConversionHelper.RemoveDiacritics(input);

        url = ConversionHelper.RemoveNonAlphanumericCharacters(url);
        
        url = ConversionHelper.ReplaceSpaces(url, options);
        
        if (options.Case != StringCase.UNCHANGED)
        {
            url = ConversionHelper.ChangeCase(url, options.Case);
        }

        if (options.MaxLength != 0)
        {
            url = ConversionHelper.TrimString(url, options);
        }

        return options.Prepend + url + options.Append;
    }
}