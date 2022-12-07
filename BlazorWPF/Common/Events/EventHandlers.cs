using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWPF.Common.Events
{
    public delegate void SelectedEventHandler(object sender, SelectionEventArgs args);
    public delegate void ExpandedEventHandler(object sender, ExpandedEventArgs args);
    public static class EventHandlers
    {
    }
}
