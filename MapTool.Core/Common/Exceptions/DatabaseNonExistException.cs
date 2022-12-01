using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapTool.Core.Common.Exceptions
{
    public class DatabaseNonExistException : MapToolException
    {
        public DatabaseNonExistException(string message) : base(message)
        {
        }
    }
}
