using Enums;
using System;
using System.Diagnostics;

namespace DesktopReload.Widget
{
    public class BootTimeWidget : BasicWidget
    {

        PerformanceCounter systemUpTime = new PerformanceCounter("System", "System Up Time");

        public BootTimeWidget()
        {
            LabelText = "Boot Time";
            Type = WidgetType.UpTime;
            RefreshRate = WidgetRefreshRate.None;
            ValueText = new DateTime().ToString();
            Refresh();
        }

        public DateTime getBootTime()
        {

            systemUpTime.NextValue();
            TimeSpan upTimeSpan = TimeSpan.FromSeconds(systemUpTime.NextValue());

            return DateTime.Now.Subtract(upTimeSpan);
        }

        public override void Refresh()
        {
            base.Refresh();
            ValueText = string.Format("{0: yyyy MM dd hh\\:mm\\:ss}", getBootTime());
        }
    }
}
