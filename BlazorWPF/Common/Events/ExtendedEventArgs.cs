using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWPF.Common
{
    public class ExtendedEventArgs<T> : EventArgs
    {
        public ExtendedEventArgs(object? source, T? data = default)
        {
            Source = source;
            Data = data;
        }
        public object? Source { get; private set; }
        public T? Data { get; private set; } = default;
    }
}
