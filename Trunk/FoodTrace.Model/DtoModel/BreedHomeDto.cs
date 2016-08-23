using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.Model.DtoModel
{
    public class BreedHomeDto
    {
        public int HomeID { get; set; }
        public int? AreaID { get; set; }
        public string AreaName { get; set; }
        public string HomeName { get; set; }
        public string Who { get; set; }
        public string People { get; set; }
        public string HealthStatus { get; set; }
        public DateTime? CreateTime { get; set; }
        public string Responsibility { get; set; }
        public string VarietyName { get; set; }

        public string Variety { get; set; }
        public string Area { get; set; }
        public string Remark { get; set; }
        public bool? IsLocked { get; set; }
        public bool? IsShow { get; set; }
    }
}
