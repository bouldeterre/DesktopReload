using System.Linq;
using NAudio.CoreAudioApi;
using Enums;

namespace DesktopReload.Widget
{
    public class SoundWaveWidget : BasicWidget
    {
        MMDeviceEnumerator enumerator = new MMDeviceEnumerator();
        private MMDeviceCollection collection;
        public SoundWaveWidget()
        {
            LabelText = "Sound Wave";
            Type = WidgetType.SoundOutputList;
            ViewType = WidgetViewType.SimpleGraph;
            RefreshRate = WidgetRefreshRate.Realtime;
            collection = enumerator.EnumerateAudioEndPoints(DataFlow.All, DeviceState.Active);
        }

        public override void Refresh()
        {
            base.Refresh();
            ValueText = "";
            var device = collection.ToArray()[0];
            ValueText = device.AudioMeterInformation.MasterPeakValue.ToString();
            //+= device.AudioMeterInformation.MasterPeakValue;
        }
    }
}
