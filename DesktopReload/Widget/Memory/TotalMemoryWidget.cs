using DesktopReload.Model;
using DesktopReloaded;
using Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DesktopReload.Widget
{

    public class TotalMemoryWidget : BasicWidget
    {
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool GlobalMemoryStatusEx([In, Out] MEMORYSTATUSEX lpBuffer);

        ulong installedMemory;

        public TotalMemoryWidget()
        {
           LabelText = "Total Memory";
           Type = WidgetType.AvailableRAM;

            MEMORYSTATUSEX memStatus = new MEMORYSTATUSEX();
            if (GlobalMemoryStatusEx(memStatus))
            {
                installedMemory = memStatus.ullTotalPhys;
            }
            float gigs = installedMemory / (float)1024 / (float)1024 / (float)1000;
            ValueText = string.Format("{0}gb", (Math.Round(gigs)).ToString());
        }

        public override void Refresh()
        {
            base.Refresh();
            MEMORYSTATUSEX memStatus = new MEMORYSTATUSEX();
            if (GlobalMemoryStatusEx(memStatus))
            {
                installedMemory = memStatus.ullTotalPhys;
            }
            float gigs = installedMemory / (float)1024 / (float)1024 / (float)1000;
            ValueText = string.Format("{0}gb", (Math.Round(gigs)).ToString());
        }
    }
}
