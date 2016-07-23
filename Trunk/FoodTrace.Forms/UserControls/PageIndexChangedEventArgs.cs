using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FoodTrace.Forms.UserControls
{
    public class PageIndexChangedEventArgs : RoutedEventArgs
    {
        public PageIndexChangedEventArgs(RoutedEvent routedEvent, object source) : base(routedEvent, source) { }

        public int PageIndex { get; set; }
    }
}
