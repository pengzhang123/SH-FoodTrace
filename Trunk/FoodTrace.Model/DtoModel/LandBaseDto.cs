using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.Model.DtoModel
{
    public class LandBaseDto
    {
        public int LandId { get; set; }

        public string LandName { get; set; }

        /// <summary>
        /// 1:种植,2:养殖
        /// </summary>
        public int? LandBaseType { get; set; }
        public string LandBaseTypeStr{get { return LandBaseType == 1 ? "种植" : "养殖"; }}
        public string LandCode { get; set; }
        public string CompanyName { get; set; }

        public int CompanyId { get; set; }
        public string Address { get; set; }

        public decimal? LandArea { get; set; }
    }
}
