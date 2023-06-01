using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitz.Utilities
{
    public interface IErrorHandler
    {
        #region Properties

        List<Error> Errors { get; }

        List<Error> Warnings { get; }

        #endregion Properties

        public void AddError(string Id, string Message);

        public void AddWarning(string Id, string Message);

        public bool HasErrors();

        public bool HasWarnings();

        public bool HasAny();

        public void Clear();

        public void ClearErrors();

        public void ClearWarnings();

    }
}
