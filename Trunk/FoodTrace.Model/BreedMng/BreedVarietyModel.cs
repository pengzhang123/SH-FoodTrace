using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.Model.BreedMng
{
    [Table("BMS_BREED_Variety")]
    public class BreedVarietyModel : BaseModel
    {
        [Key]
        public int VarietyId { get; set; }

        public string VarietyName { get; set; }
        public int? CompanyId { get; set; }
        public string Remark { get; set; }
        public bool? IsLocked { get; set; }
        public bool? IsShow { get; set; }
    }
}
