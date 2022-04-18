using FluentAssertions;
using StringToUrl.Enum;
using StringToUrl.Extensions;
using StringToUrl.Model;
using Xunit;

namespace StringToUrl.Tests;

public class StringToUrlTests
{
    [Theory]
    [InlineData("Māori", "maori")]
    [InlineData("Discover Māori culture in New Zealand", "discover-maori-culture-in-new-zealand")]
    [InlineData("Discover  Māori culture in New Zealand", "discover-maori-culture-in-new-zealand")]
    [InlineData("(0800) hi", "0800-hi")]
    public void Url_Can_Be_Generated_From_Default_Options(string input, string expected)
    {
        // Arrange

        // Act
        var result = input.ConvertToUrl();
        
        // Assert
        result.Should().BeEquivalentTo(expected);
    }
    
    [Theory]
    [InlineData("Māori", "MAORI")]
    [InlineData("Discover Māori culture in New Zealand", "DISCOVER-MAORI-CULTURE-IN-NEW-ZEALAND")]
    [InlineData("Discover  Māori culture in New Zealand", "DISCOVER-MAORI-CULTURE-IN-NEW-ZEALAND")]
    [InlineData("(0800) hi", "0800-HI")]
    public void Generated_Url_Can_Have_Case_Overridden(string input, string expected)
    {
        // Arrange
        var options = new UrlOptions()
        {
            Case = StringCase.Upper
        };
        
        // Act
        var result = input.ConvertToUrl(options);
        
        // Assert
        result.Should().BeEquivalentTo(expected);
    }
    
    [Theory]
    [InlineData("Māori", "maori")]
    [InlineData("Discover Māori culture in New Zealand", "discover_maori_culture_in_new_zealand")]
    [InlineData("(0800) hi", "0800_hi")]
    [InlineData("(0800) hi", "0800_HI")]
    public void Generated_Url_Can_Have_Space_Character_Overridden(string input, string expected)
    {
        // Arrange
        var options = new UrlOptions()
        {
            SpaceReplacementCharacter = "_"
        };
        
        // Act
        var result = input.ConvertToUrl(options);
        
        // Assert
        result.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [InlineData("Māori", "MAORI")]
    [InlineData("Discover Māori culture in New Zealand", "discover-m")]
    [InlineData("Discover  Māori culture in New Zealand", "discover-m")]
    [InlineData("(0800) hi", "0800-hi")]
    public void Generated_Url_Can_Have_Max_Length_Overridden(string input, string expected)
    {
        // Arrange
        var options = new UrlOptions()
        {
            MaxLength = 10
        };

        // Act
        var result = input.ConvertToUrl(options);

        // Assert
        result.Should().BeEquivalentTo(expected);
    }
    
    [Theory]
    [InlineData("@#$@#$@#", "")]
    [InlineData("Song title! - By Artist!", "song-title-by-artist")]
    [InlineData("Song title (feat. Artist2) - By Artist1.", "song-title-feat-artist2-by-artist1")]
    public void Invalid_Characters_Are_Stripped_Out_In_Generated_Url(string input, string expected)
    {
        // Arrange

        // Act
        var result = input.ConvertToUrl();

        // Assert
        result.Should().BeEquivalentTo(expected);
    }
    
    [Fact]
    public void Generated_Url_Cannot_End_With_Space_Replacement_Character()
    {
        // Arrange
        const string input = "Hello there";
        const string expected = "hello";
        var options = new UrlOptions()
        {
            MaxLength = 6
        };
        
        // Act
        var result = input.ConvertToUrl(options);
        
        // Assert
        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void Generated_Url_Can_Have_Domain_Prepended()
    {
        // Arrange
        const string input = "Charlie Puth That's Hilarious";
        const string expected = "https://google.co.nz/charlie-puth-thats-hilarious";
        var options = new UrlOptions()
        {
            Prepend = "https://google.co.nz/"
        };
        
        // Act
        var result = input.ConvertToUrl(options);
        
        // Assert
        result.Should().BeEquivalentTo(expected);
    }
    
    [Fact]
    public void Generated_Url_Can_Have_String_Appended()
    {
        // Arrange
        const string input = "Charlie Puth That's Hilarious";
        const string expected = "charlie-puth-thats-hilarious/8743897";
        var options = new UrlOptions()
        {
            Append = "/8743897"
        };
        
        // Act
        var result = input.ConvertToUrl(options);
        
        // Assert
        result.Should().BeEquivalentTo(expected);
    }
    
    [Fact]
    public void Generated_Url_Can_Have_Strings_Appended_Prepended()
    {
        // Arrange
        const string input = "Charlie Puth That's Hilarious";
        const string expected = "https://google.co.nz/charlie-puth-thats-hilarious/8743897";
        var options = new UrlOptions()
        {
            Prepend = "https://google.co.nz/",
            Append = "/8743897"
        };
        
        // Act
        var result = input.ConvertToUrl(options);
        
        // Assert
        result.Should().BeEquivalentTo(expected);
    }
}