using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodTrace.Model
{
    public class TreeModelDto
    {
     
    }

    /// <summary>
    /// ztree的实体Model
    /// </summary>
    public class ZtreeModel
    {
         //SimpleData模式
        public ZtreeModel()
        {
            this.url = string.Empty;
            this.icon = string.Empty;
            this.Checked = false;
            this.open = true;
        }
        public string id { get; set; }

        public string name { get; set; }

        public string pId { get; set; }

        public bool open { get; set; }

        public bool isParent { get; set; }

        public bool nocheck { get; set; }

        public bool Checked { get; set; }

        public string icon { get; set; }
        public string url { get; set; }

        public int type { get; set; }
    }
}
