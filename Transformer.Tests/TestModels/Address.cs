namespace Neemle.Utils.JsonTransformer.Tests.TestModels;

public partial class Address
{
    public string? Street { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
    public string? PostalCode { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj is not Address other) return false;

        return Street == other.Street &&
               City == other.City &&
               Country == other.Country &&
               PostalCode == other.PostalCode;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Street, City, Country, PostalCode);
    }
}
