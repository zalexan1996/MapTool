using BlazorWPF.Common.Events;
using BlazorWPF.Components.TreeViewItem;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWPF.Components.TreeView
{
    public partial class TreeView
    {
        private List<TreeViewItem.TreeViewItem> _items = new List<TreeViewItem.TreeViewItem>();
        public TreeViewItem.TreeViewItem? SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                // Deselect the previous item.
                if (_selectedItem != null)
                {
                    _selectedItem.IsSelected = false;
                }

                // Set the new item reference,
                _selectedItem = value;

                // Select the new item.
                if (_selectedItem != null)
                {
                    _selectedItem.IsSelected = true;
                }
            }
        }
        private TreeViewItem.TreeViewItem ?_selectedItem;

        public void CollapseAll()
        {
            _items.Where(i => i.IsExpanded)
                .ToList()
                .ForEach(i => i.IsExpanded = false);
        }
        public void ExpandAll()
        {
            _items.Where(i => !i.IsExpanded)
                .ToList()
                .ForEach(i => i.IsExpanded = true);
        }

        public void RegisterChild(TreeViewItem.TreeViewItem item)
        {
            _items.Add(item);
            item.SelectedEvent += onTreeViewItemSelected;
        }

        private void onTreeViewItemSelected(object sender, SelectionEventArgs args)
        {
            var tvi = sender as TreeViewItem.TreeViewItem;

            if (tvi != null)
            {
                if (_selectedItem != null)
                {
                    _selectedItem.IsSelected = false;
                }
                _selectedItem = tvi;
            }
        }
    }
}
