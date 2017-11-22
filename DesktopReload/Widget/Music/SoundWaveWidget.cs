using System.Linq;
using NAudio.CoreAudioApi;
using Enums;

namespace DesktopReload.Widget
{
    public class SoundWaveWidget : BasicWidget
    {
        MMDeviceEnumerator enumerator = new MMDeviceEnumerator();
        private MMDeviceCollection collection;
        private int _graphValue = 90;

        public int GraphValue
        {
            get { return _graphValue; }
            set
            {
                SetField(ref _graphValue, value, "GraphValue");
            }
        }

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
            var device = collection.ToArray()[0];
            GraphValue = (int) (device.AudioMeterInformation.MasterPeakValue * 100);
        }
    }
}
