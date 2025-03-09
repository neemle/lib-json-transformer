using System.Text.Json;

namespace Neemle.Utils.JsonTransformer;

public static class JsonTransformer
{
    public static string Encode<T>(T obj, JsonSerializerOptions? options = null)
    {
        return JsonSerializer.Serialize(obj, options);
    }

    public static T Decode<T>(string json, JsonSerializerOptions? options = null)
    {
        var value = JsonSerializer.Deserialize<T>(json, options);
        if (value == null) throw new Exception($"Cannot deserialize {typeof(T).Name} from {json}");
        return value;
    }
}