using Microsoft.AspNetCore.Components;

namespace BlazorWPF.Common
{
    public class BlazorWPFComponent : ComponentBase
    {
        [Parameter]
        public object? Tag { get; set; }

        [Parameter]
        public string ToolTip { get; set; } = "";

        [Parameter]
        public RenderFragment? ContextMenu { get; set; } = null;

        [Parameter]
        public string Name { get; set; } = "";

    }
}
