namespace Neemle.Utils.JsonTransformer.Samples;

/// <summary>
/// Приклад класу для демонстрації серіалізації та десеріалізації
/// </summary>
public partial class Person
{
    public string? Name { get; set; }
    public int Age { get; set; }
    public bool IsActive { get; set; }
    public Address? Address { get; set; }
}
