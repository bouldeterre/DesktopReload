using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.CoreAudioApi;
using Enums;
using System.Collections.ObjectModel;

namespace DesktopReload.Widget.Music
{
    public class SoundOutputListWidget : BasicWidget
    {
        MMDeviceEnumerator enumerator = new MMDeviceEnumerator();
        private MMDeviceCollection collection;
        ObservableCollection<string> LabelTextList = new ObservableCollection<string>()
        {
            "Audio1",
            "Audio2",
            "Audio3"
        };

        public SoundOutputListWidget()
        {
            LabelText = "Sound Outputs:";
            Type = WidgetType.SoundOutputList;
            ViewType = WidgetViewType.LabelList;

            collection = enumerator.EnumerateAudioEndPoints(DataFlow.All, DeviceState.Active);
        }

        public void getData()
        {
            LabelTextList.Clear();
            var cat = new System.Diagnostics.PerformanceCounterCategory("PhysicalDisk");
            var list = cat.GetInstanceNames();
            foreach (var output in collection.ToArray())
            {
                LabelTextList.Add(output.FriendlyName);
            }
        }

        public override void Refresh()
        {
            base.Refresh();
            getData();
        }
    }
}
