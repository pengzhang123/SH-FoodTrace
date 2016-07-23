using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodTrace.Model
{
    /// <summary>
    /// 批次产品种植计划
    /// </summary>
    [Table("BMS_PLANS_BATCH")]
    public class PlansBatchModel : BaseModel
    {
        [Key]
        public int BatchID { get; set; }

        public int? BlockID { get; set; }
        [ForeignKey("BlockID")]
        public virtual LandBlockModel LandBlock { get; set; }

        public int? SeedID { get; set; }
        [ForeignKey("SeedID")]
        public virtual SeedBaseModel SeedBase { get; set; }

        public string BatchNO { get; set; }
        public string BatchCode { get; set; }
        public DateTime? PlansTime { get; set; }
        public string PlansYear { get; set; }
        public DateTime? HarvestTime { get; set; }
        public decimal? PlansArea { get; set; }
        public string ChargePerson { get; set; }
        public decimal? HarvestCount { get; set; }
        public decimal? RealCount { get; set; }
        public string People { get; set; }
        public string Remark { get; set; }
        public bool? IsLocked { get; set; }
        public bool? IsShow { get; set; }

        public virtual ICollection<PlansDrugModel> PlansDrug { get; set; }
        public virtual ICollection<PlansFertModel> PlansFert { get; set; }
    }
}
