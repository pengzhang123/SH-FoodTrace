using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.Model.DtoModel
{
    public class BreedBaseDto
    {
        public int BreedID { get; set; }
        public int? LandID { get; set; }

        public string LandName { get; set; }
        public string BreedName { get; set; }
        public int? BreedCode { get; set; }
        public string BreedArea { get; set; }
        public string BreedType { get; set; }
        public string Lon { get; set; }
        public string Lat { get; set; }
        public string Remark { get; set; }
        public bool? IsLocked { get; set; }
        public bool? IsShow { get; set; }
    }
}
