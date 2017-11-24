using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using DesktopReload.Controls;
using DesktopReloaded.Interfaces;
using Enums;
using System.Windows.Input;
using NAudio.CoreAudioApi;

namespace DesktopReloaded
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IList<IBasicWidget> widgets = new List<IBasicWidget>();
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

            WidgetService = new GetWidgetService();
            widgets = WidgetService.GetWidgets();
            CreateViews();
        }

        private void CreateViews()
        {
            if (widgets != null)
                foreach (var widget in widgets)
                {
                    UserControl elemWidget = null;

                    switch (widget.ViewType)
                    {
                        case WidgetViewType.Label:
                            elemWidget = createLabelWidget(widget);
                            break;
                        case WidgetViewType.LabelList:
                            elemWidget = createLabelListWidget(widget);
                            break;
                        case WidgetViewType.SimpleGraph:
                            elemWidget = createSimpleGraphWidget(widget);
                            break;
                        case WidgetViewType.MusicPlayer:
                            elemWidget = createMusicPlayerWidget(widget);
                            break;
                    }
                    if (elemWidget != null)
                    {
                        elemWidget.DataContext = widget;
                        GeneralStack.Children.Add(elemWidget);
                    }
                }
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            //base.OnMouseDown(e);
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }


        private UserControl createLabelListWidget(IBasicWidget widget)
        {
            var control = new LabelListControl();
            return control;
        }

        private UserControl createLabelWidget(IBasicWidget widget)
        {
            var control = new LabelControl();
            return control;
        }

        private UserControl createSimpleGraphWidget(IBasicWidget widget)
        {
            var control = new SimpleGraphControl();
            return control;
        }

        private UserControl createMusicPlayerWidget(IBasicWidget widget)
        {
            var control = new MusicPlayerControl();
            return control;
        }
    }
}