using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.Model.BaseDto
{
    public class GridList<T> where T :class 
    {
        public GridList()
        {
            this.total = 0;
            this.rows=new List<T>();
        }
        public int total { get; set; }

        public List<T> rows { get; set; } 
    }
}
