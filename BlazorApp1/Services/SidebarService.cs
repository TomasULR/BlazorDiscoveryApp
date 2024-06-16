using System;

namespace BlazorApp1.Services
{
    public class SidebarService
    {
        public event Action OnChange;
        public bool showSidebar = false;

        public bool ShowSidebar
        {
            get => showSidebar;
            private set
            { 
                    showSidebar = value;
                    //NotifyStateChanged();
                
            }
        }

        //private void NotifyStateChanged() => OnChange?.Invoke();

        public void SetSidebarVisibility(bool isVisible)
        {
            ShowSidebar = isVisible;
        }
    }
}
