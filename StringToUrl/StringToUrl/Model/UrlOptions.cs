using StringToUrl.StringToUrl.Enum;

namespace StringToUrl.StringToUrl.Model;

public class UrlOptions
{
    /// <summary>
    /// You can override the character that spaces are replaced with. By default it is -
    /// </summary>
    public string SpaceReplacementCharacter { get; set; } = "-";

    /// <summary>
    /// Override the case which the output string is.
    /// </summary>
    public StringCase Case { get; set; } = StringCase.LOWER;

    /// <summary>
    /// The max length you want a URL to be. If set, the URL will be cut off after this length.
    /// </summary>
    public int MaxLength { get; set; } = 0;
}