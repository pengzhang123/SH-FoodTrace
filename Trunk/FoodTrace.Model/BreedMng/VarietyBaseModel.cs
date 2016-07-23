using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodTrace.Model
{
    [Table("BMS_VARIETY_BASE")]
    public class VarietyBaseModel:BaseModel
    {
        [Key]
        public int VarietyID { get; set; }
        public int? DistType { get; set; }
        public string VarietyType { get; set; }
        public string VarietyCode { get; set; }
        public string VarietyName { get; set; }

        public string Remark { get; set; }
        public bool? IsLocked { get; set; }
        public bool? IsShow { get; set; }
    }
}
