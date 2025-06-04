using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace Neemle.Utils.JsonTransformer;

[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties)]
public static class JsonTransformerOptions
{
    // Статичні поля замість методів, щоб уникнути попереджень IL2026
    private static readonly JsonSerializerOptions _prettyPrintOptions = new() { WriteIndented = true };
    private static readonly JsonSerializerOptions _singleLineOptions = new() { WriteIndented = false };

    /// <summary>
    /// Опції для форматованого JSON (безпечно для обрізки коду)
    /// </summary>
    public static JsonSerializerOptions PrettyPrint => _prettyPrintOptions;

    /// <summary>
    /// Опції для однорядкового JSON (безпечно для обрізки коду)
    /// </summary>
    public static JsonSerializerOptions SingleLine => _singleLineOptions;

    /// <summary>
    /// Створює опції для форматованого JSON (безпечно для обрізки коду)
    /// </summary>
    public static JsonSerializerOptions CreatePrettyPrintOptions()
    {
        return new JsonSerializerOptions { WriteIndented = true };
    }

    /// <summary>
    /// Створює опції для однорядкового JSON (безпечно для обрізки коду)
    /// </summary>
    public static JsonSerializerOptions CreateSingleLineOptions()
    {
        return new JsonSerializerOptions { WriteIndented = false };
    }
}