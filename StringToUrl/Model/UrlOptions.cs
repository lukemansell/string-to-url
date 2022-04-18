using StringToUrl.Enum;

namespace StringToUrl.Model;

/// <summary>
/// An object which allows you to pass through extra configuration to override some of the default settings which occur
/// when converting a string to a URL path.
/// </summary>
public class UrlOptions
{
    /// <summary>
    /// You can override the character that spaces are replaced with. By default it is -
    /// </summary>
    public string SpaceReplacementCharacter { get; set; } = "-";

    /// <summary>
    /// Override the case which the output string is.
    /// </summary>
    public StringCase Case { get; set; } = StringCase.Lower;

    /// <summary>
    /// The max length you want a URL to be. If set, the URL will be cut off after this length.
    /// </summary>
    public int MaxLength { get; set; } = 0;

    /// <summary>
    /// Add to the end of the generated URL
    /// </summary>
    public string? Append { get; set; }

    /// <summary>
    /// Add to the start of the generated URL. Eg: your domain
    /// </summary>
    public string? Prepend { get; set; }
}