using System.Text.Json;
using System.Text.Json.Serialization;
using Neemle.Utils.JsonTransformer.Tests.TestModels;
using Xunit;

namespace Neemle.Utils.JsonTransformer.Tests;

public partial class JsonTransformerTests
{
    private readonly Person _testPerson = new()
    {
        Name = "Іван Петренко",
        Age = 30,
        IsActive = true,
        Address = new Address
        {
            Street = "вул. Шевченка, 10",
            City = "Київ",
            Country = "Україна",
            PostalCode = "01001"
        }
    };

    [Fact]
    public void Encode_WithObject_ReturnsValidJson()
    {
        // Arrange
        var expected = JsonSerializer.Serialize(_testPerson);

        // Act
        var result = JsonTransformer.Encode(_testPerson);

        // Assert
        Assert.NotNull(result);
        Assert.NotEmpty(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Encode_WithObjectAndOptions_ReturnsValidJson()
    {
        // Arrange
        var options = new JsonSerializerOptions { WriteIndented = true };
        var expected = JsonSerializer.Serialize(_testPerson, options);

        // Act
        var result = JsonTransformer.Encode(_testPerson, options);

        // Assert
        Assert.NotNull(result);
        Assert.NotEmpty(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Encode_WithObjectAndTypeInfo_ReturnsValidJson()
    {
        // Arrange
        var expected = JsonSerializer.Serialize(_testPerson, PersonContext.Default.Person);

        // Act
        var result = JsonTransformer.Encode(_testPerson, PersonContext.Default.Person);

        // Assert
        Assert.NotNull(result);
        Assert.NotEmpty(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Decode_WithValidJson_ReturnsObject()
    {
        // Arrange
        var json = JsonSerializer.Serialize(_testPerson);

        // Act
        var result = JsonTransformer.Decode<Person>(json);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(_testPerson.Name, result.Name);
        Assert.Equal(_testPerson.Age, result.Age);
        Assert.Equal(_testPerson.IsActive, result.IsActive);
        Assert.Equal(_testPerson.Address?.Street, result.Address?.Street);
        Assert.Equal(_testPerson.Address?.City, result.Address?.City);
        Assert.Equal(_testPerson.Address?.Country, result.Address?.Country);
        Assert.Equal(_testPerson.Address?.PostalCode, result.Address?.PostalCode);
    }

    [Fact]
    public void Decode_WithValidJsonAndOptions_ReturnsObject()
    {
        // Arrange
        var options = new JsonSerializerOptions { WriteIndented = true };
        var json = JsonSerializer.Serialize(_testPerson, options);

        // Act
        var result = JsonTransformer.Decode<Person>(json, options);

        // Assert
        Assert.NotNull(result);
        AssertPersonEqual(_testPerson, result);
    }

    [Fact]
    public void Decode_WithValidJsonAndTypeInfo_ReturnsObject()
    {
        // Arrange
        var json = JsonSerializer.Serialize(_testPerson, PersonContext.Default.Person);

        // Act
        var result = JsonTransformer.Decode(json, PersonContext.Default.Person);

        // Assert
        Assert.NotNull(result);
        AssertPersonEqual(_testPerson, result);
    }

    private void AssertPersonEqual(Person expected, Person actual)
    {
        Assert.Equal(expected.Name, actual.Name);
        Assert.Equal(expected.Age, actual.Age);
        Assert.Equal(expected.IsActive, actual.IsActive);

        if (expected.Address == null)
        {
            Assert.Null(actual.Address);
        }
        else
        {
            Assert.NotNull(actual.Address);
            Assert.Equal(expected.Address.Street, actual.Address.Street);
            Assert.Equal(expected.Address.City, actual.Address.City);
            Assert.Equal(expected.Address.Country, actual.Address.Country);
            Assert.Equal(expected.Address.PostalCode, actual.Address.PostalCode);
        }
    }

    [Fact]
    public void Decode_WithInvalidJson_ThrowsException()
    {
        // Arrange
        var json = "{\"invalid\": true";

        // Act & Assert
        Assert.Throws<JsonException>(() => JsonTransformer.Decode<Person>(json));
    }

    [Fact]
    public void Decode_WithInvalidJsonAndTypeInfo_ThrowsException()
    {
        // Arrange
        var json = "{\"invalid\": true";

        // Act & Assert
        Assert.Throws<JsonException>(() => JsonTransformer.Decode(json, PersonContext.Default.Person));
    }

    [Fact]
    public void Decode_WithNull_ThrowsException()
    {
        // Arrange
        var json = "null";

        // Act & Assert
        Assert.Throws<Exception>(() => JsonTransformer.Decode<Person>(json));
    }

    [Fact]
    public void Decode_WithNullAndTypeInfo_ThrowsException()
    {
        // Arrange
        var json = "null";

        // Act & Assert
        Assert.Throws<Exception>(() => JsonTransformer.Decode(json, PersonContext.Default.Person));
    }

    [Fact]
    public void Encode_DeserializeRoundTrip_MaintainsObjectIntegrity()
    {
        // Arrange
        var person = new Person
        {
            Name = "Тарас Шевченко",
            Age = 47,
            IsActive = true,
            Address = new Address
            {
                Street = "вул. Хрещатик, 1",
                City = "Київ",
                Country = "Україна",
                PostalCode = "01001"
            }
        };

        // Act
        var json = JsonTransformer.Encode(person);
        var result = JsonTransformer.Decode<Person>(json);

        // Assert
        AssertPersonEqual(person, result);
    }

    [Fact]
    public void Encode_DeserializeRoundTripWithTypeInfo_MaintainsObjectIntegrity()
    {
        // Arrange
        var person = new Person
        {
            Name = "Леся Українка",
            Age = 42,
            IsActive = true,
            Address = new Address
            {
                Street = "вул. Франка, 5",
                City = "Львів",
                Country = "Україна",
                PostalCode = "79000"
            }
        };

        // Act
        var json = JsonTransformer.Encode(person, PersonContext.Default.Person);
        var result = JsonTransformer.Decode(json, PersonContext.Default.Person);

        // Assert
        AssertPersonEqual(person, result);
    }

    [JsonSerializable(typeof(Person))]
    [JsonSerializable(typeof(Address))]
    public partial class PersonContext : JsonTransformerContext<Person>
    {
        // Примітка: властивість Default буде автоматично згенерована
    }
}
