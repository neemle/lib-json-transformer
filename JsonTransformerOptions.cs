using System.Text.Json;

namespace Neemle.Utils.JsonTransformer;

public class JsonTransformerOptions
{
    public static JsonSerializerOptions PrettyPrint => new() { WriteIndented = true };
    public static JsonSerializerOptions SingleLine => new() { WriteIndented = false };
}