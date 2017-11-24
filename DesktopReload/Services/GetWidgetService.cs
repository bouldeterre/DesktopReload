using DesktopReload.Widget;
using DesktopReload.Widget.Music;
using DesktopReloaded.Interfaces;
using System;
using System.Collections.Generic;
using Enums;

namespace DesktopReloaded
{

    public class GetWidgetService : IGetWidgetService
    {
        IList<IBasicWidget> widgets = new List<IBasicWidget>();
        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer(priority: System.Windows.Threading.DispatcherPriority.Background);
        System.Windows.Threading.DispatcherTimer LeastdispatcherTimer = new System.Windows.Threading.DispatcherTimer(priority: System.Windows.Threading.DispatcherPriority.Background);
        System.Windows.Threading.DispatcherTimer RealtimedispatcherTimer = new System.Windows.Threading.DispatcherTimer(priority: System.Windows.Threading.DispatcherPriority.Background);

        public IList<IBasicWidget> GetWidgets()
        {
            widgets.Add(new BootTimeWidget());
            widgets.Add(new UpTimeWidget());
            widgets.Add(new CPUCountWidget());
            widgets.Add(new CPUWidget());
            widgets.Add(new CPUListWidget());

            widgets.Add(new TotalMemoryWidget());
            widgets.Add(new AvailableMemoryWidget());
            widgets.Add(new DiskListWidget());
            widgets.Add(new DiskReadWidget());
            widgets.Add(new DiskWriteWidget());

            widgets.Add(new SoundOutputListWidget());
            widgets.Add(new SoundVolumeWidget());

            widgets.Add(new SoundWaveWidget());
            widgets.Add(new SpotifyWidget());
            
            return widgets;
        }


        public GetWidgetService()
        {
            LeastdispatcherTimer.Tick += new EventHandler(RefreshLeastWidgets);
            LeastdispatcherTimer.Interval = new TimeSpan(0, 0, 10);
            LeastdispatcherTimer.Start();

            dispatcherTimer.Tick += new EventHandler(RefreshWidgets);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();

            RealtimedispatcherTimer.Tick += new EventHandler(RefreshRealtimeWidgets);
            RealtimedispatcherTimer.Interval = new TimeSpan(0, 0, 0, 1, 0);
            RealtimedispatcherTimer.Start();

        }

        private void RefreshLeastWidgets(object sender, EventArgs e)
        {
            foreach (var widgets in widgets)
            {
                if (widgets.RefreshRate == WidgetRefreshRate.Least)
                    widgets.Refresh();
            }
        }

        private void RefreshWidgets(object sender, EventArgs e)
        {
            foreach(var widgets in widgets)
            {
                if (widgets.RefreshRate == WidgetRefreshRate.Default)
                    widgets.Refresh();
            }
        }

        private void RefreshRealtimeWidgets(object sender, EventArgs e)
        {
            foreach (var widgets in widgets)
            {
                if (widgets.RefreshRate == WidgetRefreshRate.Realtime)
                    widgets.Refresh();
            }
        }
    }
}
