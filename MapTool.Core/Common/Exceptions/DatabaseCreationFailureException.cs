using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapTool.Core.Common.Exceptions
{

    public class DatabaseCreationFailureException : MapToolException
    {
        public enum FailureReason
        {
            DatabaseAlreadyExists,
            FilePathError,
            Unknown
        }
        public DatabaseCreationFailureException(string message, FailureReason failureReason = FailureReason.Unknown)
            :
            base($"{failureReason} - {message}")
        {

        }
    }
}
