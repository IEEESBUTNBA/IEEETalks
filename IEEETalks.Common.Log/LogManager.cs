namespace IEEETalks.Common.Log
{
    public static class LogManager
    {
        private static ILog _current;

        public static ILog Current
        {
            get
            {
                if (_current == null)
                    UseDefault();

                return _current;
            }
        }

        public static void UseTraceLogger()
        {
            _current = new TraceLogger();
        }

        public static void UseDefault()
        {
            UseTraceLogger();
        }
    }
}