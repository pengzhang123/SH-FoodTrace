using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.Micro;
using System.ComponentModel.Composition;

namespace FoodTrace.Forms.ViewModels
{
    [Export(typeof(PlansBaseViewModel))]
    public class PlansBaseViewModel : Screen, IMainScreenTabItem
    {
        public PlansBaseViewModel()
        {
            DisplayName = "PlansBaseViewModel";
            TabItemIndex = 0;
        }

        public int TabItemIndex { get; set; }
    }
}
