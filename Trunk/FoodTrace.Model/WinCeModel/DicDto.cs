using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.Model
{

    public class DicDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// 用药方法:DrugMethod,防治对象:DrugObject,病虫害类型:DrugInsect,用药名称:Drug,天气:Weather
        /// </summary>
        public string Type { get; set; }
    }
}
