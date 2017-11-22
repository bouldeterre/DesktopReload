using Enums;
using System;
using System.Diagnostics;

namespace DesktopReload.Widget
{
    public class CPUWidget : BasicWidget
    {
        private PerformanceCounter pc = new PerformanceCounter("Processor", "% Processor Time", "_Total");

        public CPUWidget()
        {
            LabelText = "CPU Time";
            Type = WidgetType.CPU;
            RefreshRate = WidgetRefreshRate.Default;
            ValueText = string.Format("{0}", getUptime());
        }

        public float getUptime()
        {
            var tmp = pc.NextValue();
            return tmp; // (float)(Math.Round((double)tmp, 1));;
        }

        public override void Refresh()
        {
            base.Refresh();
            var val = getUptime();
            ValueText = val.ToString();

        }
    }
}
