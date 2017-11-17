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
    public class CPUCountWidget : BasicWidget
    {
        public CPUCountWidget()
        {
            LabelText = "CPU Cores Count";
            Type = WidgetType.CPUCoresCount;
            ValueText = string.Format("{0}", getData());
        }

        public float getData()
        {
            return Environment.ProcessorCount;
        }

        public override void Refresh()
        {
            base.Refresh();
            var val = getData();
            ValueText = val.ToString();

        }
    }
}
