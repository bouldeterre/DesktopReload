using DesktopReload.Controls;
using DesktopReloaded.Interfaces;
using Enums;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace DesktopReloaded
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GetWidgetService WidgetService;

        List<IBasicWidget> widgets = new List<IBasicWidget>();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            WidgetService = new GetWidgetService();

            widgets = WidgetService.GetWidgets();

            CreateViews();
        }

        void CreateViews()
        {
            if ( widgets != null)
            foreach (var widget in widgets) {
                Control elemWidget = null;

                switch (widget.ViewType)
                {
                    case WidgetViewType.Label:
                        elemWidget = createLabelWidget(widget);
                        break;
                }
                elemWidget.DataContext = widget;
                if (elemWidget != null)
                    GeneralStack.Children.Add(elemWidget);
            }

        }

        private Control createLabelWidget(IBasicWidget widget)
        {
            var label = new LabelControl();
            return label;
        }
    }
}
