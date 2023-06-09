using System.Diagnostics;

namespace Fitz.Utilities
{
    public interface IError
    {
        string Id { get; }

        string Message { get; }

        StackTrace StackTrace { get; }
    }
}
