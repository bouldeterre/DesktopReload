using DesktopReloaded;
using Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace DesktopReload.Widget
{
    public class DiskWriteWidget : BasicWidget
    {
        private PerformanceCounter pc = new PerformanceCounter("PhysicalDisk", "Disk Write Bytes/sec", "_Total");

        public DiskWriteWidget()
        {
            LabelText = "Disk Write";
            Type = WidgetType.DiskWrite;
            ValueText = string.Format("{0}KB/s", getData());
        }

        public float getData()
        {
            float tmp = pc.NextValue() / 1024;
            var DISKWrite = (float)(Math.Round((double)tmp, 1));
            return DISKWrite;
        }

        public override void Refresh()
        {
            base.Refresh();
            var val = string.Format("{0}KB/s", getData());
            ValueText = val.ToString();

        }
    }
}
