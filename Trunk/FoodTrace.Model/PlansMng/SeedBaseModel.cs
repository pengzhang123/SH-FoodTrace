using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodTrace.Model
{
    /// <summary>
    /// 种植种子基本信息
    /// </summary>
    [Table("BMS_SEED_BASE")]
    public class SeedBaseModel : BaseModel
    {
        [Key]
        public int SeedID { get; set; }
        public string SeedCode { get; set; }
        public string SeedNO { get; set; }
        public string SeedName { get; set; }
        public string BatchNO { get; set; }
        public string Place { get; set; }
        public string Supplier { get; set; }
        public string PurchPerson { get; set; }
        public DateTime? BuyTime { get; set; }
        public decimal? BuyCount { get; set; }
        public string Units { get; set; }
        public string Remark { get; set; }
        public bool? IsLocked { get; set; }
        public bool? IsShow { get; set; }

        public virtual ICollection<PlansBatchModel> PlansBatch { get; set; }
    }
}
