using System;
using System.Diagnostics;

namespace IEEETalks.Common.Log
{
    internal class TraceLogger : ILog
    {
        public string Name { get; set; }
        public bool Enabled { get; set; }

        public void Debug(string message)
        {
            DebugFormat(message);
        }

        public void Debug(string message, Exception exception)
        {
            const string msg = "Message: {0} - Error: {1}";
            DebugFormat(msg, message, exception.Message);
        }

        public void DebugFormat(string format, params object[] args)
        {
            Trace.TraceInformation(format, args);
        }

        public void Info(string message)
        {
            InfoFormat(message);
        }

        public void Info(string message, Exception exception)
        {
            const string msg = "Message: {0} - Error: {1}";
            InfoFormat(msg, message, exception.Message);
        }

        public void InfoFormat(string format, params object[] args)
        {
            Trace.TraceInformation(format, args);
        }

        public void Warn(string message)
        {
            WarnFormat(message);
        }

        public void Warn(string message, Exception exception)
        {
            const string msg = "Message: {0} - Error: {1}";
            WarnFormat(msg, message, exception.Message);
        }

        public void WarnFormat(string format, params object[] args)
        {
            Trace.TraceWarning(format, args);
        }

        public void Error(string message)
        {
            ErrorFormat(message);
        }

        public void Error(Exception exception)
        {
            const string msg = "Error: {1}";
            ErrorFormat(msg, exception.Message);
        }

        public void Error(string message, Exception exception)
        {
            const string msg = "Message: {0} - Error: {1}";
            ErrorFormat(msg, message, exception.Message);
        }

        public void ErrorFormat(string format, params object[] args)
        {
            Trace.TraceError(format, args);
        }

        public void Fatal(string message)
        {
            FatalFormat(message);
        }

        public void Fatal(string message, Exception exception)
        {
            const string msg = "Message: {0} - Error: {1}";
            FatalFormat(msg, message, exception.Message);
        }

        public void FatalFormat(string format, params object[] args)
        {
            Trace.TraceError(format, args);
            // TODO: send an email
        }
    }
}