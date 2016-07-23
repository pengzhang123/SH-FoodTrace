using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodTrace.Model
{
    /// <summary>
    /// 种植施肥情况
    /// </summary>
    [Table("BMS_PLANS_FERT")]
    public class PlansFertModel : BaseModel
    {
        [Key]
        public int FertID { get; set; }

        public int? BatchID { get; set; }
        [ForeignKey("BatchID")]
        public virtual PlansBatchModel PlansBatch { get; set; }

        public string FertCode { get; set; }
        public string FertName { get; set; }
        public string FertPeople { get; set; }
        public DateTime? FertTime { get; set; }
        public string FertType { get; set; }
        public string FertMethod { get; set; }
        public string UANum { get; set; }
        public string Weather { get; set; }
        public string Pic { get; set; }
        public string PlansCode { get; set; }
        public string Remark { get; set; }
        public bool? IsLocked { get; set; }
        public bool? IsShow { get; set; }

        public virtual ICollection<PlansFertPicModel> PlansFertPic { get; set; }
        public virtual ICollection<PlansFertVideoModel> PlansFertVideo { get; set; }
    }

    /// <summary>
    /// 种植施肥情况多图片
    /// </summary>
    [Table("BMS_PLANS_FERT_PIC")]
    public class PlansFertPicModel : BasePicModel
    {
        [Key]
        public int PicID { get; set; }

        public int? FertID { get; set; }
        [ForeignKey("FertID")]
        public PlansFertModel PlansFert { get; set; }
    }

    /// <summary>
    /// 种植施肥情况多视频
    /// </summary>
    [Table("BMS_PLANS_FERT_VIDEO")]
    public class PlansFertVideoModel : BaseVideoModel
    {
        [Key]
        public int VideoID { get; set; }

        public int? FertID { get; set; }
        [ForeignKey("FertID")]
        public PlansFertModel PlansFert { get; set; }
    }
}
