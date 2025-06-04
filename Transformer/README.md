# Neemle.Utils.JsonTransformer

A library for simple JSON serialization and deserialization with code trimming support in .NET 9.

## Size Optimization

This library is optimized for minimal size using the following technologies:

- `PublishTrimmed` - removal of unused code
- `TrimMode=link` - aggressive trimming mode for maximum size reduction
- `InvariantGlobalization` - removal of unnecessary localization resources
- `OptimizationPreference=Size` - optimization for size instead of performance
- `DebuggerSupport=false` - removal of debugging support

## Code Trimming Support

This library supports code trimming in .NET 9 with two approaches:

### 1. Regular Methods (with code trimming warnings)

These methods have the `RequiresUnreferencedCode` attribute, which may cause warnings when code trimming is enabled:

```csharp
// This may cause IL2026 warnings when code trimming is enabled
var json = JsonTransformer.Encode(person);
var person = JsonTransformer.Decode<Person>(json);
```

### 2. Trimming-Safe Methods (using JsonTypeInfo)

These methods do not cause warnings when code trimming is enabled, but require the use of `JsonTypeInfo` or `JsonSerializerContext`:

```csharp
// Creating a serialization context
// The Default property is automatically generated in each derived class
[JsonSerializable(typeof(Person))]
public partial class PersonContext : JsonTransformerContext<Person> {}

// Usage in code (without IL2026 warnings)
var json = JsonTransformer.Encode(person, PersonContext.Default.Person);
var person = JsonTransformer.Decode(json, PersonContext.Default.Person);
```

## Features

### Methods with Warnings During Code Trimming

- `JsonTransformer.Encode<T>(obj, options)` - serialization of an object to a JSON string
- `JsonTransformer.Decode<T>(json, options)` - deserialization of a JSON string to an object
- `JsonTransformerOptions.PrettyPrint` - options for formatted JSON (safe for code trimming)
- `JsonTransformerOptions.SingleLine` - options for single-line JSON (safe for code trimming)

### Trimming-Safe Methods

- `JsonTransformer.Encode<T>(obj, jsonTypeInfo)` - serialization of an object to a JSON string
- `JsonTransformer.Decode<T>(json, jsonTypeInfo)` - deserialization of a JSON string to an object
- `JsonTransformerOptions.CreatePrettyPrintOptions()` - creating options for formatted JSON
- `JsonTransformerOptions.CreateSingleLineOptions()` - creating options for single-line JSON
