using System;
using System.IO;
using System.Reflection;

namespace IEEETalks.Common
{
    public class ApplicationSettings : IApplicationSettings
    {
        public string Version => Assembly.GetExecutingAssembly().GetName().Version.ToString(3);

        public string ApplicationNameVersion => $"{ApplicationName} v{Version}";

        public string ApplicationName => "IEEETalks";

        //public string ApplicationName => System.Reflection.Assembly.GetEntryAssembly().GetName().Name;

        public string ContextDirectory => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ApplicationName);

        public string DbConnectionString => "mongodb://localhost:27017";
        public string DbName => "IEEETalks-Default";

        public string AcceptedOriginRequestsUrl => "http://localhost:56951";
    }
}
