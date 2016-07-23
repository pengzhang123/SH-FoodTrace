using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodTrace.Model
{
    /// <summary>
    /// 种植企业基地地块
    /// </summary>
    [Table("BMS_LAND_BLOCK")]
    public class LandBlockModel : BaseModel
    {
        [Key]
        public int BlockID { get; set; }
        public int? LandID { get; set; }

        [ForeignKey("LandID")]
        public virtual LandBaseModel LandBase { get; set; }

        public string BlockCode { get; set; }
        public string BlockName { get; set; }
        public decimal? BlockArea { get; set; }
        public string SoilType { get; set; }
        public string SoilName { get; set; }
        public string SoilSalinity { get; set; }
        public string SoilQuality { get; set; }
        public string Toc { get; set; }
        public string LakerSalinity { get; set; }
        public string WaterSalinity { get; set; }
        public string GroundWater { get; set; }
        public string WaterQuality { get; set; }
        public string Lon { get; set; }
        public string Lat { get; set; }
        public string Remark { get; set; }
        public bool? IsLocked { get; set; }
        public bool? IsShow { get; set; }

        public virtual ICollection<PlansBatchModel> PlansBatch { get; set; }
    }
}
