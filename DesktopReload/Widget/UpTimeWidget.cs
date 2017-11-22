using Enums;
using System;
using System.Diagnostics;

namespace DesktopReload.Widget
{
    public class UpTimeWidget : BasicWidget
    {
        private PerformanceCounter uptime = new PerformanceCounter("System", "System Up Time");

        public UpTimeWidget()
        {
            LabelText = "Up Time";
            Type = WidgetType.UpTime;
            RefreshRate = WidgetRefreshRate.Default;

            ValueText = string.Format("{0:hh\\:mm\\:ss}", getUptime());
        }

        public TimeSpan getUptime()
        {
            return TimeSpan.FromSeconds(uptime.NextValue());
        }

        public override void Refresh()
        {
            base.Refresh();
            ValueText = string.Format("{0:hh\\:mm\\:ss}", getUptime());

        }
    }
}
