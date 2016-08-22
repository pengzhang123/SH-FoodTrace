using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.Model.DtoModel
{
    public class BreedVarietyDto
    {
        public int VarietyId { get; set; }

        public string VarietyName { get; set; }
        public int? CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Remark { get; set; }
        public bool? IsLocked { get; set; }
        public bool? IsShow { get; set; }
        public int? ModifyID { get; set; }
        public string ModifyName { get; set; }
        public DateTime? ModifyTime { get; set; }
    }
}
