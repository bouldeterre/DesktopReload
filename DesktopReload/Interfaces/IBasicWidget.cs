using Enums;

namespace DesktopReloaded.Interfaces
{
    public interface IBasicWidget
    {
        string LabelText { get; }
        string ValueText { get; }
        WidgetViewType ViewType { get ; }
        WidgetType Type { get; }
        WidgetRefreshRate RefreshRate { get; }

        void Refresh();
    }
}
