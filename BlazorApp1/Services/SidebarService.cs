using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.Services
{
    public class SidebarService
    {
        public event Action OnChange;
        private bool showSidebar = true;

        public bool ShowSidebar
        {
            get => showSidebar;
            set
            {
                showSidebar = value;
                NotifyStateChanged();
            }
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
