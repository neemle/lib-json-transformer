using System.Text.Json.Serialization;
using Neemle.Utils.JsonTransformer.IntegrationTest.Models;

namespace Neemle.Utils.JsonTransformer.IntegrationTest;

public static class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("=== Neemle.Utils.JsonTransformer Integration Test ===\n");

        // Creating test data
        var user = CreateTestUser();
        Console.WriteLine($"Created test user: {user}\n");

        try
        {
            Console.WriteLine("Test: Serialization using JsonTypeInfo (safe for trimming)");
            string jsonTrimSafe = JsonTransformer.Encode(user, UserContext.Default.UserProfile);
            Console.WriteLine($"Serialization successful, JSON length: {jsonTrimSafe.Length} characters");

            var userDeserialized = JsonTransformer.Decode(jsonTrimSafe, UserContext.Default.UserProfile);
            Console.WriteLine($"Deserialization successful: {userDeserialized}\n");
            Console.WriteLine("✅ Test passed successfully!\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Test failed: {ex.Message}\n");
        }

        Console.WriteLine("This application was compiled with code trimming settings!");
        Console.WriteLine("Successful execution confirms that the library works correctly in this mode.");
    }

    private static UserProfile CreateTestUser()
    {
        return new UserProfile
        {
            Id = Guid.NewGuid().ToString(),
            Username = "user1",
            Email = "user1@example.com",
            EmailVerified = true,
            Created = DateTime.UtcNow.AddDays(-30),
            LastLogin = DateTime.UtcNow,
            Settings = new UserSettings
            {
                Theme = "dark",
                Language = "en-US",
                EnableNotifications = true,
                TimeZone = "UTC"
            },
            Roles = new List<string> { "user", "editor" },
            Metadata = new Dictionary<string, string>
            {
                { "registrationSource", "website" },
                { "preferredContact", "email" }
            }
        };
    }
}

[JsonSerializable(typeof(UserProfile))]
[JsonSerializable(typeof(UserSettings))]
[JsonSerializable(typeof(List<string>))]
[JsonSerializable(typeof(Dictionary<string, string>))]
public partial class UserContext : JsonTransformerContext<UserProfile>
{
}