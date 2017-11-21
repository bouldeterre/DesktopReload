using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DesktopReload.Controls
{
    /// <summary>
    /// Interaction logic for SimpleGraphControl.xaml
    /// </summary>
    public partial class SimpleGraphControl : UserControl
    {

        readonly WriteableBitmap bitmap;
        readonly int ptr;
      
        public SimpleGraphControl()
        {
            InitializeComponent();


            var width  = (int)ControlImage.Width ;
            var height = (int) ControlImage.Height;

        }


    }
}
