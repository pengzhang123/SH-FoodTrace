using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.Model.DtoModel
{
    public class LandBlockDto
    {
        public int BlockID { get; set; }

        public string LandBaseName { get; set; }

        public string BlockName { get; set; }
        public string BlockCode { get; set; }

        public decimal? BlockArea { get; set; }

        public string SoilType { get; set; }
        public string SoilName { get; set; }
        public string SoilSalinity { get; set; }

        public string SoilQuality { get; set; }

        public string Lon { get; set; }
        public string Lat { get; set; }

        public string Remark { get; set; }
        public string Toc { get; set; }
        public string LakerSalinity { get; set; }
        public string WaterSalinity { get; set; }
        public string GroundWater { get; set; }
        public string WaterQuality { get; set; }
        public bool? IsLocked { get; set; }
        public bool? IsShow { get; set; }
    }
}
