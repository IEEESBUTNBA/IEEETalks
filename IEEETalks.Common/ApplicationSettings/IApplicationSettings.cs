namespace IEEETalks.Common
{
    public interface IApplicationSettings
    {
        string AcceptedOriginRequestsUrl { get; }
        string ApplicationName { get; }
        string ApplicationNameVersion { get; }
        string ContextDirectory { get; }
        string DbConnectionString { get; }
        string Version { get; }
        string DbName { get; }
    }
}