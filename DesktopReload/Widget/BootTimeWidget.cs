using Enums;
using System;

namespace DesktopReloaded.Services
{
    public class BootTimeWidget : BasicWidget
    {

        public BootTimeWidget()
        {
            LabelText = "Boot Time";
            Type = WidgetType.UpTime;
            ValueText = "";
        }

        public DateTime getBootTime()
        {
            return new DateTime();
        }

        public override void Refresh()
        {
            base.Refresh();

        }
    }
}
