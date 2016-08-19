using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.Model
{
    public class ResultJson
    {
        public ResultJson()
        {
            this.IsSuccess = false;
            Items=new Dictionary<string, object>();
        }

        public bool IsSuccess { get; set; }
        public string Msg { get; set; }
        public object Data { get; set; }

        public Dictionary<string, object> Items { get; set; }
    }
}
