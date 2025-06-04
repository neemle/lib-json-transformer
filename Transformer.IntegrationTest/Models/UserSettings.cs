namespace Neemle.Utils.JsonTransformer.IntegrationTest.Models;

public class UserSettings
{
    public string? Theme { get; set; }
    public string? Language { get; set; }
    public bool EnableNotifications { get; set; }
    public string? TimeZone { get; set; }

    public override string ToString()
    {
        return $"UserSettings {{Theme={Theme}, Language={Language}, TimeZone={TimeZone}}}";
    }
}
