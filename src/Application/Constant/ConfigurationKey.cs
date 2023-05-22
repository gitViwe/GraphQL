namespace Application.Constant;

/// <summary>
/// Provides the keys to get the values from AppSettings
/// </summary>
public static class ConfigurationKey
{
    /// <summary>
    /// Provides the keys to get the values from the ConnectionStrings section
    /// </summary>
    public static class ConnectionString
    {
        public const string PostgreSQL = "PostgreSQL";
        public const string SQLite = "SQLite";
    }
}
