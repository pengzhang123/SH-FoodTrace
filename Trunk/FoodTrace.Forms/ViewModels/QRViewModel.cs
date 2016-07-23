using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace FoodTrace.Forms.ViewModels
{
    [Export(typeof(QRViewModel))]
    public class QRViewModel : ViewAware
    {
        public BitmapImage QRImage { get; set; }
    }
}
