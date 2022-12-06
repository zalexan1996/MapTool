using Microsoft.AspNetCore.Components;

namespace MapTool.Blazor.Shared.EditorComponents.TreeView
{
    public class TreeViewItemInfo
    {
        public TreeViewItemInfo(string name, string iconName = "spreadsheet", string? title = null)
        {
            Name = name;
            IconName = iconName;
            Title = title ?? name;
        }
        public string Name { get; set; } = "";

        public string Title { get; set; } = "";

        public string IconName { get; set; }

        public List<TreeViewItemInfo> Children { get; set; } = new();
    }
}
