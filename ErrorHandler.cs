using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
