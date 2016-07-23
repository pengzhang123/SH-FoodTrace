using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodTrace.Model
{
    [Table("BMS_BREED_AREA")]
    public class BreedAreaModel:BaseModel
    {
        [Key]
        public int AreaID { get; set; }
        public int? BreedID { get; set; }
        [ForeignKey("BreedID")]
        public virtual BreedBaseModel BreedBase { get; set; }
        public string AreaName { get; set; }
        public string Area { get; set; }
        public string Who { get; set; }
        public string Variety { get; set; }
        public string People { get; set; }
        public DateTime? CreateTime { get; set; }
        public string Responsibility { get; set; }
        public string Remark { get; set; }
        public bool? IsLocked { get; set; }
        public bool? IsShow { get; set; }
    }
}
