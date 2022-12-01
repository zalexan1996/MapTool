using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapTool.Core.Common.Exceptions
{
    public class MapToolException : Exception
    {
        private readonly DateTime _occuredOn;
        public MapToolException(string message)
            :
            base($"{message}")
        {
            _occuredOn= DateTime.Now;
        }
    }
}
