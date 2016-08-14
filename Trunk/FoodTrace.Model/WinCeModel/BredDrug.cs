using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.Model.WinCeModel
{
    public class WinCeModel
    {
        public string Epc { get; set; }
       // public string UserName { get; set; }
    }
    public class BredDrug:WinCeModel
    {
        /// <summary>
        /// 用药方法
        /// </summary>
        public string DrugMethod { get; set; }
        /// <summary>
        /// 用药名称
        /// </summary>
        public string Drug { get; set; }

        /// <summary>
        /// 防治对象
        /// </summary>
        public string DrugObject { get; set; }
        /// <summary>
        /// 病虫害类型
        /// </summary>
        public string DrugInsect { get; set; }

        /// <summary>
        /// 天气
        /// </summary>
        public string Weather { get; set; }
        /// <summary>
        /// 用量(千克)
        /// </summary>
        public string Dosage { get; set; }

        /// <summary>
        /// 稀释倍数
        /// </summary>
        public string Dilute { get; set; }
    }

    public class BreedHealth:WinCeModel
    {
        public string Health { get; set; }

        public string Weather { get; set; }
    }

    public class BreedMaterial:WinCeModel
    {
        public string MaterialType { get; set; }
        public string MaterialName { get; set; }
        public string MaterialMethod { get; set; }

        public string Weather { get; set; }

        public string MaterialCot { get; set; }  
    }
}
