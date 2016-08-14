using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.Model.DtoModel
{
    public class ProductInfoDto
    {
        public ProductInfoDto()
        {

            this.ProductImage = string.Empty;
        }

        public int Code { get; set; }
        /// <summary>
        /// 牲畜，养殖：1，皮影:2,种植：3
        /// </summary>
        public int Type { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// 规格
        /// </summary>
        public string SpecName { get; set; }
        /// <summary>
        /// 类别
        /// </summary>
        public string TypeName { get; set; }
        /// <summary>
        /// 来源部位
        /// </summary>
        public string SourceName { get; set; }

        public string CompanyName { get; set; }

        public string ShelfLife { get; set; }

        public double? Price { get; set; }

        public double? Weight { get; set; }

        public string QsNum { get; set; }

        public string ProductImage { get; set; }
    }


    public class ProductTraceDto
    {
        public ProductTraceDto()
        {
            this.Image = string.Empty;
        }
        public int Code { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// 牲畜：1，养殖场:2,屠宰场:3,屠宰加工仓库：4， 加工厂：5，销售仓库：6，销售公司：7,产品:8,父：9，母:10,种植场：11，种子：12
        /// </summary>
        public int Type { get; set; }

        public string Image { get; set; }

        public object DetailData { get; set; }
    }
}
