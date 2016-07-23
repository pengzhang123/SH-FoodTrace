using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.Forms.Models
{
    public class NaviModel
    {
        public string Name { get; set; }
        public int NaviIndex { get; set; }
        public bool IsExpanded { get; set; }
        public Object SelectedExpander { get; set; }
        public IEnumerable<string> Menus { get; set; }
    }
}
