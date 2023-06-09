using System.Diagnostics;

namespace Fitz.Utilities
{
    public class ErrorHandler : IErrorHandler
    {
        public List<IError> Errors { get; }

        public List<IError> Warnings { get; }

        public ErrorHandler()
        {
            Errors = new List<IError>();

            Warnings = new List<IError>();
        }

        public IErrorHandler AddError(string Id, string Message)
        {
            StackTrace stackTrace = new StackTrace(true);

            Error error = new Error(Id, Message, stackTrace);

            Errors.Add(error);

            return this;
        }

        public IErrorHandler AddWarning(string Id, string Message)
        {
            StackTrace stackTrace = new StackTrace(true);

            Error error = new Error(Id, Message, stackTrace);

            Warnings.Add(error);

            return this;
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

        public IErrorHandler Clear()
        {
            Errors.Clear();
            Warnings.Clear();

            return this;
        }

        public IErrorHandler ClearErrors()
        {
            Errors.Clear();

            return this;
        }

        public IErrorHandler ClearWarnings()
        {
            Warnings.Clear();

            return this;
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
