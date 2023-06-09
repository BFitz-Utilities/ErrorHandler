using System.Diagnostics;

namespace Fitz.Utilities
{
    public class Error : IError
    {
        public string Id { get; set; }

        public string Message { get; set; }

        public StackTrace StackTrace { get; set; }

        private StackFrame? _StackFrame;

        public Error(string id, string message, StackTrace stackTrace)
        {
            Id = id;
            Message = message;
            StackTrace = stackTrace;

            _StackFrame = StackTrace.GetFrame(1) ?? StackTrace.GetFrame(0);
        }

        public override string ToString()
        {
            return String.Format("Error: {0} | Message: {1} | Method: {2} | Line: {3} | File: {4}", Id, Message, _StackFrame?.GetMethod(), _StackFrame?.GetFileLineNumber(), _StackFrame?.GetFileName());
        }
    }

    public class Warning : Error
    {
        public Warning(string id, string message, StackTrace stackTrace) : base(id, message, stackTrace) { }
    }
}
