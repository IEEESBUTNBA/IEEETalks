using System;
using FluentValidation.Results;

namespace IEEETalks.Common
{
    public interface IGuard
    {
        void ForDateBetween2000AndNextYear(DateTime value, string parameterName, string message);
        void ForDateRange(DateTime value, DateTime greaterDate, string parameterName, string message);
        void ForLessEqualZero(int value, string parameterName, string message);
        void ForNull(object value, string parameterName, string attemptedValue, string message);
        void ForNullOrEmpty(string value, string parameterName, string message);
        void ForValidationResult(ValidationResult validation);
    }
}