using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.Model.DtoModel
{
    public class BreedAreaDto
    {
        public int AreaID { get; set; }
        public int? BreedID { get; set; }
        public string BreedName { get; set; }
        public string AreaName { get; set; }
        public string Area { get; set; }
        public string Who { get; set; }
        public int? VarietyId { get; set; }
        public string Variety { get; set; }
        public string People { get; set; }
        public DateTime? CreateTime { get; set; }
        public string Responsibility { get; set; }
        public string Remark { get; set; }
        public bool? IsLocked { get; set; }
        public bool? IsShow { get; set; }
    }
}
