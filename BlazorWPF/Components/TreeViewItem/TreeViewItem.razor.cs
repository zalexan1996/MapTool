using BlazorWPF.Common;
using BlazorWPF.Common.Events;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWPF.Components.TreeViewItem
{
    public partial class TreeViewItem : BlazorWPFComponent
    {
        #region Events
        public event ExpandedEventHandler? CollapsedEvent;
        public event ExpandedEventHandler? ExpandedEvent;

        public event SelectedEventHandler? SelectedEvent;
        #endregion

        #region Properties
        [Parameter, EditorRequired]
        public string Header { get; set; }

        [Parameter]
        public string HeaderIcon { get; set; } = "eye";

        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                _isSelected = value;
                if (_isSelected)
                {
                    SelectedEvent?.Invoke(this, new(this, true));
                }

                StateHasChanged();
            }
        }
        private bool _isSelected;

        public bool IsExpanded
        {
            get
            {
                return _isExpanded;
            }
            set
            {
                _isExpanded = value;

                if (_isExpanded)
                {
                    ExpandedEvent?.Invoke(this, new(this, true));
                }
                else
                {
                    CollapsedEvent?.Invoke(this, new(this, false));
                }
            }
        }
        private bool _isExpanded;
        #endregion
    }
}
