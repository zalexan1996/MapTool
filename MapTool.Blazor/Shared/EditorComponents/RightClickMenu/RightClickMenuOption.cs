namespace MapTool.Blazor.Shared.EditorComponents.RightClickMenu
{
    public class RightClickMenuOption
    {
        public string Name { get; set; }
        public EventHandler OnClick { get; private set; }
        public string IconName { get; set; }

    }
}
