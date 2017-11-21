using System.Collections.Generic;

namespace DesktopReloaded.Interfaces
{
    public interface IGetWidgetService
    {
        IList<IBasicWidget> GetWidgets();
    }
}
