using Enums;
using System;
using System.Diagnostics;

namespace DesktopReloaded.Services
{
    public class UpTimeWidget : BasicWidget
    {

        public UpTimeWidget()
        {
            LabelText = "Up Time";
            Type = WidgetType.UpTime;
            ValueText = string.Format("{0:hh\\:mm\\:ss}", getUptime());
        }

        public TimeSpan getUptime()
        {
            using (var uptime = new PerformanceCounter("System", "System Up Time"))
            {
                uptime.NextValue();       //Call this an extra time before reading its value
                return TimeSpan.FromSeconds(uptime.NextValue());
            }
        }

        public override void Refresh()
        {
            base.Refresh();
            ValueText = string.Format("{0:hh\\:mm\\:ss}", getUptime());

        }
    }
}
