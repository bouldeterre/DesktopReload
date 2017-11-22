using Enums;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace DesktopReload.Widget
{
    public class CPUListWidget : BasicWidget
    {
        PerformanceCounterCategory cat = new System.Diagnostics.PerformanceCounterCategory("Processor");

        public ObservableCollection<string> LabelTextList { get; set; }

        public CPUListWidget()
        {
            LabelText = "CPU List";
            Type = WidgetType.CPUList;
            RefreshRate = WidgetRefreshRate.None;
            ViewType = WidgetViewType.LabelList;
            LabelTextList = new ObservableCollection<string>()
            {
                "CPU1",
                "CPU2",
                "CPU3"
            };
            getData();
        }

        public void getData()
        {
            LabelTextList.Clear();
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
