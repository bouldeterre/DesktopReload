using DesktopReloaded;
using Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopReload.Widget
{
    public class CPUListWidget : BasicWidget
    {
        PerformanceCounter pc = new PerformanceCounter("PhysicalDisk", "Disk Read Bytes/sec", "_Total");

        ObservableCollection<string> LabelTextList = new ObservableCollection<string>()
        {
            "CPU1",
            "CPU2",
            "CPU3"
        };
        public CPUListWidget()
        {
            LabelText = "CPU List";
            Type = WidgetType.CPUList;
            ViewType = WidgetViewType.LabelList;
        }

        public void getData()
        {
            LabelTextList.Clear();
            var cat = new System.Diagnostics.PerformanceCounterCategory("Processor");            
            var list = cat.GetInstanceNames();
            foreach (var cpu in list)
            {
                LabelTextList.Add(cpu);
            }
        }

        public override void Refresh()
        {
            base.Refresh();
            getData();
        }
    }
}
