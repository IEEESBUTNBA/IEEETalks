namespace IEEETalks.Common.IoC
{
    public static class Container
    {
        private static IContainer _current;

        public static IContainer Current
        {
            get
            {
                if (_current == null)
                    UseDefault();

                return _current;
            }
        }

        public static void UseStructureMap()
        {
            _current = new StructureMapContainer();
        }

        public static void UseDefault()
        {
            UseStructureMap();
        }
    }
}
