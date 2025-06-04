namespace Neemle.Utils.JsonTransformer.Tests.TestModels;

public partial class Person
{
    public string? Name { get; set; }
    public int Age { get; set; }
    public bool IsActive { get; set; }
    public Address? Address { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj is not Person other) return false;

        bool addressEqual = (Address == null && other.Address == null) ||
                           (Address != null && other.Address != null && Address.Equals(other.Address));

        return Name == other.Name &&
               Age == other.Age &&
               IsActive == other.IsActive &&
               addressEqual;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Age, IsActive, Address);
    }
}
