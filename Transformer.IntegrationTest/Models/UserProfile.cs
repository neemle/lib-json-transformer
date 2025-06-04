namespace Neemle.Utils.JsonTransformer.IntegrationTest.Models;

public class UserProfile
{
    public string? Id { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
    public bool EmailVerified { get; set; }
    public DateTime Created { get; set; }
    public DateTime LastLogin { get; set; }
    public UserSettings? Settings { get; set; }
    public List<string>? Roles { get; set; }
    public Dictionary<string, string>? Metadata { get; set; }

    public override string ToString()
    {
        return $"UserProfile {{Id={Id}, Username={Username}, Email={Email}, Roles={string.Join(", ", Roles ?? new List<string>())}}}";
    }
}
