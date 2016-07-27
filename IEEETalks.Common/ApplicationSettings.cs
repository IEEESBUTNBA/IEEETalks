using System;
using System.IO;
using System.Reflection;

namespace IEEETalks.Common
{
    public class ApplicationSettings
    {
        public static string Version => Assembly.GetExecutingAssembly().GetName().Version.ToString(3);

        public static string ApplicationNameVersion => $"{ApplicationName} v{Version}";

        public static string ApplicationName => "IEEETalks";

        //public static string ApplicationName => System.Reflection.Assembly.GetEntryAssembly().GetName().Name;

        public static string ContextDirectory => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ApplicationName);

        public static string DbConnectionString => "mongodb://localhost:27017";
        public static string AcceptedOriginRequestsUrl => "http://localhost:56951";
    }
}
