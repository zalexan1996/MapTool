using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWPF.Common.Events
{
    public class ExpandedEventArgs : ExtendedEventArgs<bool>
    {
        public ExpandedEventArgs(object? source, bool isCollapsed) : base(source, isCollapsed)
        {

        }
        public bool IsCollapsed => Data;
    }
}
