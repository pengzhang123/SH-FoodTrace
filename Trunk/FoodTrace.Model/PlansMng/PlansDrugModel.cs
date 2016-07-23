using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodTrace.Model
{
    /// <summary>
    /// 种植用药情况
    /// </summary>
    [Table("BMS_PLANS_DRUG")]
    public class PlansDrugModel : BaseModel
    {
        [Key]
        public int DrugID { get; set; }

        public int? BatchID { get; set; }
        [ForeignKey("BatchID")]
        public virtual PlansBatchModel PlansBatch { get; set; }

        public string People { get; set; }
        public string Object { get; set; }
        public string DrugName { get; set; }
        public DateTime? DrugTime { get; set; }
        public string Problem { get; set; }
        public string Method { get; set; }
        public string UANum { get; set; }
        public string Dilution { get; set; }
        public string Weather { get; set; }
        public string Pic { get; set; }
        public string PlansCode { get; set; }
        public string Remark { get; set; }
        public bool? IsLocked { get; set; }
        public bool? IsShow { get; set; }

        public virtual ICollection<PlansDrugPicModel> PlansDrugPic { get; set; }
        public virtual ICollection<PlansDrugVideoModel> PlansDrugVideo { get; set; }

    }

    /// <summary>
    /// 种植用药情况（防疫）多图片
    /// </summary>
    [Table("BMS_PLANS_DRUG_PIC")]
    public class PlansDrugPicModel : BasePicModel
    {
        [Key]
        public int PicID { get; set; }

        public int? DrugID { get; set; }
        [ForeignKey("DrugID")]
        public PlansDrugModel PlansDrug { get; set; }

    }

    /// <summary>
    /// 种植用药情况（防疫）多视频
    /// </summary>
    [Table("BMS_PLANS_DRUG_VIDEO")]
    public class PlansDrugVideoModel : BaseVideoModel
    {
        [Key]
        public int VideoID { get; set; }

        public int? DrugID { get; set; }
        [ForeignKey("DrugID")]
        public PlansDrugModel PlansDrug { get; set; }
    }
}
