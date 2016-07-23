using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodTrace.Model
{
    [Table("BMS_BREED_HOME")]
    public class BreedHomeModel:BaseModel
    {
        [Key]
        public int HomeID { get; set; }
        public int? AreaID { get; set; }
        [ForeignKey("AreaID")]
        public virtual BreedAreaModel BreedArea { get; set; }
        public string HomeName { get; set; }
        public string Who { get; set; }
        public string People { get; set; }
        public string HealthStatus { get; set; }
        public DateTime? CreateTime { get; set; }
        public string Responsibility { get; set; }
        public string Variety { get; set; }
        public string Area { get; set; }
        public string Remark { get; set; }
        public bool? IsLocked { get; set; }
        public bool? IsShow { get; set; }
    }
}
