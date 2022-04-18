using StringToUrl.Model;
using StringToUrl.Service;

namespace StringToUrl.Extensions;

public static class StringExtensions
{
    /// <summary>
    /// Converts a given string to a URL format. Eg: Hello World is converted to hello-world with default options.
    /// </summary>
    /// <param name="input"></param>
    /// <param name="options">See <see cref="UrlOptions"/> on how to override certain settings.</param>
    /// <returns></returns>
    public static string ConvertToUrl(
        this string input,
        UrlOptions options)
    {
        return ConversionService.Convert(input, options);
    }
    
    /// <summary>
    /// Converts a given string to a URL format. Eg: Hello World is converted to hello-world with default options.
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static string ConvertToUrl(
        this string input)
    {
        return ConversionService.Convert(input, new UrlOptions());
    }
}