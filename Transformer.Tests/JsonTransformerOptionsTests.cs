using System.Text.Json;
using Xunit;

namespace Neemle.Utils.JsonTransformer.Tests;

public class JsonTransformerOptionsTests
{
    [Fact]
    public void PrettyPrint_ReturnsOptionsWithIndentation()
    {
        // Act
        var options = JsonTransformerOptions.PrettyPrint;

        // Assert
        Assert.NotNull(options);
        Assert.True(options.WriteIndented);
    }

    [Fact]
    public void SingleLine_ReturnsOptionsWithoutIndentation()
    {
        // Act
        var options = JsonTransformerOptions.SingleLine;

        // Assert
        Assert.NotNull(options);
        Assert.False(options.WriteIndented);
    }

    [Fact]
    public void CreatePrettyPrintOptions_ReturnsNewOptionsWithIndentation()
    {
        // Act
        var options = JsonTransformerOptions.CreatePrettyPrintOptions();

        // Assert
        Assert.NotNull(options);
        Assert.True(options.WriteIndented);
        Assert.NotSame(JsonTransformerOptions.PrettyPrint, options);
    }

    [Fact]
    public void CreateSingleLineOptions_ReturnsNewOptionsWithoutIndentation()
    {
        // Act
        var options = JsonTransformerOptions.CreateSingleLineOptions();

        // Assert
        Assert.NotNull(options);
        Assert.False(options.WriteIndented);
        Assert.NotSame(JsonTransformerOptions.SingleLine, options);
    }
}
