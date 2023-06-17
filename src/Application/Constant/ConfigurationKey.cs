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

    /// <summary>
    /// Provides the keys to get the values from the APIConfiguration section
    /// </summary>
    public static class API
    {
        public const string ApplicationName = "APIConfiguration:ApplicationName";
        public const string Secret = "APIConfiguration:Secret";
        public const string ClientUrl = "APIConfiguration:ClientUrl";
        public const string ServerUrl = "APIConfiguration:ServerUrl";
    }

    /// <summary>
    /// Provides the keys to get the values from the OpenTelemetry section
    /// </summary>
    public static class OpenTelemetry
    {
        public static class Honeycomb
        {
            public const string Endpoint = "OpenTelemetry:Honeycomb:Endpoint";
            public const string Headers = "OpenTelemetry:Honeycomb:Headers";
        }

        public static class Jaeger
        {
            public const string AgentHost = "OpenTelemetry:Jaeger:AgentHost";
            public const string AgentPort = "OpenTelemetry:Jaeger:AgentPort";
        }
    }
}
