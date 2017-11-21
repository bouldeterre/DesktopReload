using System.Linq;
using NAudio.CoreAudioApi;
using Enums;

namespace DesktopReload.Widget.Music
{
    public class SoundVolumeWidget : BasicWidget
    {
        MMDeviceEnumerator enumerator = new MMDeviceEnumerator();
        private MMDeviceCollection collection;
        public SoundVolumeWidget()
        {
            LabelText = "Sound Volume";
            Type = WidgetType.SoundOutputList;
            ViewType = WidgetViewType.Label;
            RefreshRate = WidgetRefreshRate.Realtime;
            collection = enumerator.EnumerateAudioEndPoints(DataFlow.All, DeviceState.Active);
        }

        public override void Refresh()
        {
            base.Refresh();
            ValueText = "";
            var device = collection.ToArray()[0];
            
            ValueText = ((int) (device.AudioMeterInformation.MasterPeakValue * 100)).ToString();
            //+= device.AudioMeterInformation.MasterPeakValue;
        }
    }
}
