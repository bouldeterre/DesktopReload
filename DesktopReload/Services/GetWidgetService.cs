﻿using DesktopReloaded.Interfaces;
using DesktopReloaded.Services;
using System;
using System.Collections.Generic;

namespace DesktopReloaded
{

    public class GetWidgetService : IGetWidgetService
    {
        List<IBasicWidget> widgets = new List<IBasicWidget>();
        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer(priority: System.Windows.Threading.DispatcherPriority.Background);
       
        public List<IBasicWidget> GetWidgets()
        {
            widgets.Add(new UpTimeWidget());
            return widgets;
        }


        public GetWidgetService()
        {
            dispatcherTimer.Tick += new EventHandler(RefreshWidgets);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        private void RefreshWidgets(object sender, EventArgs e)
        {
            foreach(var widgets in widgets)
            {
                widgets.Refresh();
            }
        }
    }
}