using System.Diagnostics;

namespace Fitz.Utilities
{
    public interface IError : IWarning
    {
        
    }

    public interface IWarning
    {
        string Id { get; }
        
        string Message { get; }

        StackTrace StackTrace { get; }
    }
}
