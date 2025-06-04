using System.Text.Json.Serialization;

namespace Neemle.Utils.JsonTransformer.Samples;

/// <summary>
/// Приклад контексту серіалізації для класу Person
/// </summary>
[JsonSerializable(typeof(Person))]
[JsonSerializable(typeof(Address))]
public partial class PersonContext : JsonTransformerContext<Person>
{
    // Явно вказуємо, що ми хочемо приховати батьківську властивість Default,
    // щоб уникнути попередження CS0108
    // Компілятор автоматично згенерує властивість Default з ключовим словом new
}
