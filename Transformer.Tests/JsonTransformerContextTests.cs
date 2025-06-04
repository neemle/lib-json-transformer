using System.Text.Json.Serialization;
using Neemle.Utils.JsonTransformer.Tests.TestModels;
using Xunit;

namespace Neemle.Utils.JsonTransformer.Tests;

public partial class JsonTransformerContextTests
{
    [Fact]
    public void JsonTransformerContext_HasDefaultProperty()
    {
        // Act
        var context = new TestContext();

        // Assert
        Assert.NotNull(TestContext.Default);
        Assert.NotNull(TestContext.Default.Person);
    }

    [Fact]
    public void JsonTransformerContext_CanSerialize()
    {
        // Arrange
        var person = new Person
        {
            Name = "Іван",
            Age = 25,
            IsActive = true
        };

        // Act
        var json = JsonTransformer.Encode(person, TestContext.Default.Person);
        var result = JsonTransformer.Decode(json, TestContext.Default.Person);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(person.Name, result.Name);
        Assert.Equal(person.Age, result.Age);
        Assert.Equal(person.IsActive, result.IsActive);
    }

    [JsonSerializable(typeof(Person))]
    [JsonSerializable(typeof(Address))]
    public partial class TestContext : JsonTransformerContext<Person>
    {
    }
}
