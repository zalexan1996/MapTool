using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWPF.Components.IconifyIcon
{
    public class IconifyAttribute : Attribute
    {
        public IconifyAttribute(string setName, string iconifyName)
        {
            SetName = setName;
            IconifyName = iconifyName;
        }

        public string SetName { get; set; }
        public string IconifyName { get; set; }
    }
}
