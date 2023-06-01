using System.Diagnostics;

namespace Fitz.Utilities
{
    public class ErrorHandler : IErrorHandler
    {

        private readonly LogHandler _log;

        public List<Error> Errors { get; }

        public List<Error> Warnings { get; }

        public ErrorHandler()
        {
            _log = new LogHandler("ErrorHandler");

            Errors = new List<Error>();

            Warnings = new List<Error>();
        }

        public void AddError(string Id, string Message)
        {
            StackTrace stackTrace = new StackTrace(true);

            Error error = new Error(Id, Message, stackTrace);

            Errors.Add(error);
            _log.Error(error.ToString());
        }

        public void AddWarning(string Id, string Message)
        {
            StackTrace stackTrace = new StackTrace(true);

            Error error = new Error(Id, Message, stackTrace);

            Warnings.Add(error);
            _log.Warn(error.ToString());
        }

        public bool HasErrors()
        {
            return Errors.Count > 0;
        }

        public bool HasWarnings()
        {
            return Warnings.Count > 0;
        }

        public bool HasAny()
        {
            return HasErrors() || HasWarnings();
        }

        public void Clear()
        {
            Errors.Clear();
            Warnings.Clear();
        }

        public void ClearErrors()
        {
            Errors.Clear();
        }

        public void ClearWarnings()
        {
            Warnings.Clear();
        }

        public static IErrorHandler operator +(ErrorHandler Handler1, IErrorHandler Handler2)
        {
            // Add all errors
            foreach (var error in Handler2.Errors)
                Handler1.Errors.Add(error);

            // Add all warnings
            foreach (var warning in Handler2.Warnings)
                Handler1.Warnings.Add(warning);

            return Handler1;
        }
    }
}
