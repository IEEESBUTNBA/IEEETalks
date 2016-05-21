using System;

namespace IEEETalks.Common.IoC
{
    public class ContainerException : Exception
    {
        public ContainerException()
        {
        }

        public ContainerException(Exception exception)
            : base("See 'InnerException' property for more details.", exception)
        {
        }
    }
}
