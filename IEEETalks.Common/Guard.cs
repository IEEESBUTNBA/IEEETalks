using System;
using System.Collections.Generic;
using FluentValidation;
using FluentValidation.Results;

namespace IEEETalks.Common
{
    public class Guard
    {
        private static void ThrowException(string parameterName, string attemptedValue, string message)
        {
            var failure = new ValidationFailure(parameterName, message, attemptedValue);

            throw new ValidationException(new List<ValidationFailure>() { failure });
        }

        public static void ForNullOrEmpty(string value, string parameterName, string message)
        {
            if (string.IsNullOrEmpty(value))
                ThrowException(parameterName, value, message);
        }

        public static void ForDateBetween2000AndNextYear(DateTime value, string parameterName, string message)
        {
            if (value.Year < 2000 || value.Year > (DateTime.Now.Year + 1))
                ThrowException(parameterName, value.ToString("yyyy-MM-dd HH:mm:ss"), message);
        }

        public static void ForNull(object value, string parameterName, string attemptedValue, string message)
        {
            if (value == null)
                ThrowException(parameterName, attemptedValue, message);
        }

        public static void ForLessEqualZero(int value, string parameterName, string message)
        {
            if (value <= 0)
                ThrowException(parameterName, value.ToString(), message);
        }

        public static void ForDateRange(DateTime value, DateTime greaterDate, string parameterName, string message)
        {
            if (value >= greaterDate)
                ThrowException(parameterName, $"value1:{value.ToString("yyyy-MM-dd HH:mm:ss")} - value2:{greaterDate.ToString("yyyy-MM-dd HH:mm:ss")}", message);
        }

        public static void ForValidationResult(ValidationResult validation)
        {
            if (!validation.IsValid)
                throw new ValidationException(validation.Errors);
        }
    }
}