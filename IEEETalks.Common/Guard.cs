using System;

namespace IEEETalks.Common
{
    public class Guard
    {
        public static void ForNullOrEmpty(string value, string parameterName)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(parameterName);
        }

        public static void ForDateBetween2000AndNextYear(DateTime value, string parameterName)
        {
            if (value.Year < 2000 || value.Year > (DateTime.Now.Year + 1))
                throw new ArgumentOutOfRangeException(parameterName);
        }

        public static void ForNull(object value, string parameterName)
        {
            if (value == null)
                throw new ArgumentNullException(parameterName);
        }

        public static void ForLessEqualZero(int value, string parameterName)
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(parameterName);
        }

        public static void ForDateRange(DateTime value, DateTime greaterDate, string parameterName)
        {
            if (value >= greaterDate)
                throw new ArgumentOutOfRangeException(parameterName);
        }
    }
}