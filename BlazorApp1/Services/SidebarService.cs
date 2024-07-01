using System;

namespace BlazorApp1.Services
{
    public interface ISidebarService
    {
        event Action RefreshRequested;
        void CallRequestRefresh();
        void SetSidebarVisibility(bool isVisible);
        void InitializeSidebarVisibility(bool isVisible);
    }

    public class SidebarService : ISidebarService
    {
        public event Action ?RefreshRequested;

        private bool showSidebar = false;

        public bool ShowSidebar
        {
            get => showSidebar;
            private set
            {
                if (showSidebar != value)
                {
                    showSidebar = value;
                    RefreshRequested?.Invoke();
                }
            }
        }

        public void SetSidebarVisibility(bool isVisible)
        {
            ShowSidebar = isVisible;
        }

        public void InitializeSidebarVisibility(bool isVisible)
        {
            showSidebar = isVisible;
            RefreshRequested?.Invoke();
        }

        public void CallRequestRefresh()
        {
            RefreshRequested?.Invoke();
        }
    }
}
