using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.Forms.Models
{
    public class PagerModel
    {
        public int PageCount { get; set; }
        public int TotalCount { get; set; }
        public string DetailMsg { get; set; }
       
    }
}
