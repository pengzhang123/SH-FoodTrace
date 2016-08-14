using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.Model.DtoModel
{
    public class CultivationDto
    {
        /// <summary>
        /// 牲畜，养殖：1，皮影:2,种植：3
        /// </summary>
        public int Type { get; set; }
        public ProductInfoDto ProductInfoDto { get; set; }

        public List<ProductTraceDto> ProductTraceDto { get; set; }

    }
}
