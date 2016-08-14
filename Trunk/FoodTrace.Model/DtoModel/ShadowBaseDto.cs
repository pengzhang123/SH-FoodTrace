using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.Model.DtoModel
{
    public class ShadowBaseDto
    {
        public ShadowBaseDto()
        {
            this.Type = 2;
        }
        public int Type { get; set; }

        public string Name { get; set; }
        public double? Price { get; set; }
        public double? Weight { get; set; }
        public string CompanyName { get; set; }

        public string TypeName { get; set; }

        public string Method { get; set; }

        public string Temp { get; set; }
        public string Dry { get; set; }

        public string ImgUrl { get; set; }
        public string ProcessBatch { get; set; }

    }
}
