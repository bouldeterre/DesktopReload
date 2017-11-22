using DesktopReloaded;
using Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace DesktopReload.Widget
{
    public class DiskListWidget : BasicWidget
    {
        PerformanceCounter pc = new PerformanceCounter("PhysicalDisk", "Disk Read Bytes/sec", "_Total");

        public ObservableCollection<string> LabelTextList { get; set; }

        public DiskListWidget()
        {
            Type = WidgetType.DiskList;
            ViewType = WidgetViewType.LabelList;
            RefreshRate = WidgetRefreshRate.None;
            RefreshRate = WidgetRefreshRate.Least;

            LabelText = "Disk List";
            LabelTextList = new ObservableCollection<string>()
            {
                "Disk1",
                "Disk2",
                "Disk3"
            };
        }

        public void getData()
        {
            LabelTextList.Clear();
            var cat = new System.Diagnostics.PerformanceCounterCategory("PhysicalDisk");            
            var list = cat.GetInstanceNames();
            foreach (var disk in list)
            {
                LabelTextList.Add(disk);
            }
        }

        public override void Refresh()
        {
            base.Refresh();
            getData();
        }
    }
}
