using Enums;
using System;

namespace DesktopReload.Widget
{
    public class BootTimeWidget : BasicWidget
    {

        public BootTimeWidget()
        {
            LabelText = "Boot Time";
            Type = WidgetType.UpTime;
            ValueText = new DateTime().ToString();
        }

        public DateTime getBootTime()
        {
            return new DateTime();
        }

        public override void Refresh()
        {
            base.Refresh();
            ValueText = string.Format("{0:hh\\:mm\\:ss}", getBootTime());
        }
    }
}
