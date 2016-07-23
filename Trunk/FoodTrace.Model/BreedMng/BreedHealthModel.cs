using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodTrace.Model
{
    [Table("BMS_BREED_HEALTH")]
    public class BreedHealthModel : BaseModel
    {
        [Key]
        public int HealthID { get; set; }
        public int? CultivationID { get; set; }
        [ForeignKey("CultivationID")]
        public virtual CultivationBaseModel CultivationBase { get; set; }
        public string CultivationEpc { get; set; }
        public string People { get; set; }
        public DateTime? CheckTime { get; set; }
        public string Weather { get; set; }
        public string HealthState { get; set; }
        public string Pic { get; set; }
        public string Remark { get; set; }
        public bool? IsLocked { get; set; }
        public bool? IsShow { get; set; }
    }

    /// <summary>
    /// 养殖健康情况(多图)信息
    /// </summary>
    [Table("BMS_BREED_HEALTH_PIC")]
    public class BreedHealthPicModel : BasePicModel
    {
        [Key]
        public int PicID { get; set; }

        public int? HealthID { get; set; }
        [ForeignKey("HealthID")]
        public BreedHealthModel BreedHealth { get; set; }
    }

    /// <summary>
    /// 养殖健康情况(视频)信息
    /// </summary>
    [Table("BMS_BREED_HEALTH_VIDEO")]
    public class BreedHealthVideoModel : BaseVideoModel
    {
        [Key]
        public int VideoID { get; set; }

        public int? HealthID { get; set; }
        [ForeignKey("HealthID")]
        public BreedHealthModel BreedHealth { get; set; }
    }
}
