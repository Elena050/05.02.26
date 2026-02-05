public static class AppConfig
{
    public static string Get(string key, string defaultValue = null)
    {
        return ConfigurationManager.AppSettings[key] ?? defaultValue;
    }
}

public class DatabaseService
{
    private readonly string _connectionString;

    public DatabaseService()
    {
        _connectionString = AppConfig.Get("Database:ConnectionString", "DefaultConnection");
    }
}
