using DesktopReloaded;
using Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopReload.Widget
{
    public class DiskReadWidget : BasicWidget
    {
        PerformanceCounter pc = new PerformanceCounter("PhysicalDisk", "Disk Read Bytes/sec", "_Total");

        public DiskReadWidget()
        {
            LabelText = "Disk Read";
            Type = WidgetType.DiskRead;
            ValueText = string.Format("{0}KB/s", getData());
        }

        public float getData()
        {
                float tmp = pc.NextValue() / 1024;
                var DISKRead = (float)(Math.Round((double)tmp, 1));
                return DISKRead;
        }

        public override void Refresh()
        {
            base.Refresh();
            var val = string.Format("{0}KB/s", getData());
            ValueText = val.ToString();

        }
    }
}
