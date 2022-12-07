using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWPF.Common.Events
{
    public class SelectionEventArgs : ExtendedEventArgs<bool>
    {
        public SelectionEventArgs(object? source, bool isSelected) : base(source, isSelected)
        {
        }
        public bool IsSelected => Data;
    }
}
