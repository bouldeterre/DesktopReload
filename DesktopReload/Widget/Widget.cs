using DesktopReloaded.Interfaces;
using Enums;
using System.Collections.Generic;
using System.ComponentModel;

namespace DesktopReloaded
{

    public class BasicWidget : IBasicWidget, INotifyPropertyChanged
    {
        public string name;
        private WidgetType type;
        private WidgetViewType viewType;

        private string labelText;
        private string valueText;

        public int width;
        public int height;

        public string LabelText { get => labelText; set => labelText = value; }
        public string ValueText { get => valueText;
            
                set { SetField(ref valueText, value, "ValueText"); }
            
        }

        public WidgetViewType ViewType { get => viewType; set => viewType = value; }
        public WidgetType Type { get => type; set => type = value; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, string propertyName)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }



        public BasicWidget()
        {
            width = 40;
            height = 20;

            name = "default";
            Type = WidgetType.Default;
            ViewType = WidgetViewType.Label;
            LabelText = "defaultLabel";
            ValueText = "defaultValue";
        }

        public virtual void Refresh()
        {
        }
    }
}
