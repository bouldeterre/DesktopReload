using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using DesktopReload.Controls;
using DesktopReloaded.Interfaces;
using Enums;

namespace DesktopReloaded
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly List<IBasicWidget> widgets = new List<IBasicWidget>();
        private readonly GetWidgetService WidgetService;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

#if DEBUG
            
#else
            WindowStyle = WindowStyle.None;
            AllowsTransparency = true;
            GeneralWindow.Left = 600;
            GeneralWindow.Top = 100;
#endif

            var location = new Point(100, 100);
            WidgetService = new GetWidgetService();

            widgets = WidgetService.GetWidgets();

            CreateViews();
        }

        private void CreateViews()
        {
            if (widgets != null)
                foreach (var widget in widgets)
                {
                    Control elemWidget = null;

                    switch (widget.ViewType)
                    {
                        case WidgetViewType.Label:
                            elemWidget = createLabelWidget(widget);
                            break;
                        case WidgetViewType.LabelList:
                            elemWidget = createLabelListWidget(widget);
                            break;
                    }
                    if (elemWidget != null)
                    {
                        elemWidget.DataContext = widget;
                        GeneralStack.Children.Add(elemWidget);
                    }
                }
        }

        private Control createLabelListWidget(IBasicWidget widget)
        {
            var listlabel = new LabelListControl();
            return listlabel;
        }

        private Control createLabelWidget(IBasicWidget widget)
        {
            var label = new LabelControl();
            return label;
        }
    }
}