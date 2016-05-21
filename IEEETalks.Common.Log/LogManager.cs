namespace IEEETalks.Common.Log
{
    public static class LogManager
    {
        private static ILog _logger;
        public static ILog Logger => _logger ?? (_logger = new TraceLogger());
    }
}
