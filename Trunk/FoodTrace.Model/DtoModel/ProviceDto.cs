using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.Model.DtoModel
{
    public class ProviceDto
    {
        public int ProvinceID { get; set; }

        public int? AreaID { get; set; }

        public string AreaName { get; set; }
        public string ProvinceCode { get; set; }
        public string ProvinceName { get; set; }
    }
}
