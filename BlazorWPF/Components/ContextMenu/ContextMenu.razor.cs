using BlazorWPF.Common;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWPF.Components.ContextMenu
{
    public partial class ContextMenu : BlazorWPFComponent
    {
        public double X { get; protected set; } = 0.0;
        public double Y { get; protected set; } = 0.0;
        public RenderFragment? Body { get; protected set; }

        public bool IsVisible { get; protected set; } = false;

        public void Show(double x, double y, RenderFragment? body)
        {
            X = x;
            Y = y;
            IsVisible = true;
            Body = body;
            StateHasChanged();
        }

        public void Hide()
        {
            IsVisible = false;
            StateHasChanged();
        }
    }
}
