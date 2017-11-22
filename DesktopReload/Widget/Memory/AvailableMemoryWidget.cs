using DesktopReloaded;
using Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace DesktopReload.Widget
{
    public class AvailableMemoryWidget : BasicWidget
    {
        private PerformanceCounter pc = new PerformanceCounter("Memory", "Available MBytes", null);

        public AvailableMemoryWidget()
        {
            LabelText = "Available Memory";
            Type = WidgetType.AvailableRAM;
            RefreshRate = WidgetRefreshRate.Default;
            ValueText = string.Format("{0}mb", getData());
        }

        public float getData()
        {
                var tmp = pc.NextValue();
                return tmp;
        }

        public override void Refresh()
        {
            base.Refresh();
            var val = string.Format("{0}mb", getData());
            ValueText = val.ToString();

        }
    }
}
