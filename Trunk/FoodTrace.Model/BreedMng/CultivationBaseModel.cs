using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodTrace.Model
{
    [Table("BMS_CULTIVATION_BASE")]
    public class CultivationBaseModel:BaseModel
    {
        [Key]
        public int CultivationID { get; set; }
        public int? BreedID { get; set; }

        [ForeignKey("BreedID")]
        public virtual BreedBaseModel BreedBase { get; set; }
        public int? AreaID { get; set; }

        [ForeignKey("AreaID")]
        public virtual BreedAreaModel BreedArea { get; set; }

        public int? HomeID { get; set; }
        [ForeignKey("HomeID")]
        public virtual BreedHomeModel BreedHome { get; set; }
        public string CultivationEpc { get; set; }
        public string BatchCode { get; set; }
        public string Source { get; set; }
        public int? FatherID { get; set; }
        public int? MontherID { get; set; }
        public string VarietyType { get; set; }
        public string VarietyCode { get; set; }
        public string VarietyName { get; set; }
        public DateTime? InTime { get; set; }
        public DateTime? OutTime { get; set; }
        public string OutNotes { get; set; }

        public string Remark { get; set; }
        public bool? IsLocked { get; set; }
        public bool? IsShow { get; set; }
    }
}
