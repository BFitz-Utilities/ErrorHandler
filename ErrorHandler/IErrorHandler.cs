namespace Fitz.Utilities
{
    public interface IErrorHandler
    {
        #region Properties

        List<IError> Errors { get; }

        List<IWarning> Warnings { get; }

        #endregion Properties

        public IErrorHandler AddError(string Id, string Message);

        public IErrorHandler AddWarning(string Id, string Message);

        public bool HasErrors();

        public bool HasWarnings();

        public bool HasAny();

        public IErrorHandler Clear();

        public IErrorHandler ClearErrors();

        public IErrorHandler ClearWarnings();

    }
}
