namespace PicturePortal.Settings;

public class DatabaseOptions
{
    public static string SectionName => "Database";

    public required string ConnectionString { get; init; }
    public required string DatabaseName { get; init; }
    public required string UsersCollectionName { get; init; }
}
