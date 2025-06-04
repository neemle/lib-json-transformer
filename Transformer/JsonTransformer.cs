using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace Neemle.Utils.JsonTransformer;

public static class JsonTransformer
{
    /// <summary>
    /// Серіалізує об'єкт в JSON рядок (може викликати попередження при обрізці коду)
    /// </summary>
    [RequiresUnreferencedCode("JSON serialization and deserialization might require types that cannot be statically analyzed")]
    public static string Encode<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.PublicFields)]T>(T obj, JsonSerializerOptions? options = null)
    {
        return JsonSerializer.Serialize(obj, options);
    }

    /// <summary>
    /// Десеріалізує JSON рядок в об'єкт (може викликати попередження при обрізці коду)
    /// </summary>
    [RequiresUnreferencedCode("JSON serialization and deserialization might require types that cannot be statically analyzed")]
    public static T Decode<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.PublicFields)]T>(string json, JsonSerializerOptions? options = null)
    {
        var value = JsonSerializer.Deserialize<T>(json, options);
        if (value == null) throw new Exception($"Cannot deserialize {typeof(T).Name} from {json}");
        return value;
    }

    /// <summary>
    /// Серіалізує об'єкт в JSON рядок використовуючи JsonTypeInfo (безпечно для обрізки коду)
    /// </summary>
    public static string Encode<T>(T obj, JsonTypeInfo<T> jsonTypeInfo)
    {
        return JsonSerializer.Serialize(obj, jsonTypeInfo);
    }

    /// <summary>
    /// Десеріалізує JSON рядок в об'єкт використовуючи JsonTypeInfo (безпечно для обрізки коду)
    /// </summary>
    public static T Decode<T>(string json, JsonTypeInfo<T> jsonTypeInfo)
    {
        var value = JsonSerializer.Deserialize(json, jsonTypeInfo);
        if (value == null) throw new Exception($"Cannot deserialize {typeof(T).Name} from {json}");
        return value;
    }
}