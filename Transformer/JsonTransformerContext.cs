using System.Text.Json.Serialization;

namespace Neemle.Utils.JsonTransformer;

/// <summary>
/// Базовий клас для створення типізованих контекстів серіалізації JSON
/// </summary>
/// <typeparam name="T">Тип, для якого створюється контекст</typeparam>
[JsonSerializable(typeof(object))]
public partial class JsonTransformerContext<T> : JsonSerializerContext
{
    // Базовий клас не містить властивості Default.
    // Кожен похідний клас має власну згенеровану властивість Default.
}
