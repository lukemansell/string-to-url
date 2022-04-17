using FluentAssertions;
using StringToUrl.StringToUrl.Extensions;
using Xunit;

namespace Tests;

public class StringToUrlTests
{
    [Theory]
    [InlineData("Māori", "maori")]
    [InlineData("Discover Māori culture in New Zealand", "discover-maori-culture-in-new-zealand")]
    [InlineData("Discover  Māori culture in New Zealand", "discover-maori-culture-in-new-zealand")]
    [InlineData("(0800) hi", "0800-hi")]
    public void String(string input, string expected)
    {
        // Arrange

        // Act
        var result = input.ConvertToUrl();
        
        // Assert
        result.Should().BeEquivalentTo(expected);

    }
}