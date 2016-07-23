using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodTrace.Model
{
    [Table("BMS_BREED_MATERIAL")]
    public class BreedMaterialModel : BaseModel
    {
        [Key]
        public int MaterialID { get; set; }
        public int? CultivationID { get; set; }
        [ForeignKey("CultivationID")]
        public virtual CultivationBaseModel CultivationBase { get; set; }
        public string CultivationEpc { get; set; }
        public DateTime? MaterialTime { get; set; }
        public string MaterialType { get; set; }
        public string MaterialName { get; set; }
        public string Method { get; set; }
        public int? MaterialCot { get; set; }
        public string Weather { get; set; }
        public string Pic { get; set; }
        public string Remark { get; set; }
        public bool? IsLocked { get; set; }
        public bool? IsShow { get; set; }
    }

    /// <summary>
    /// 养殖用料图片信息
    /// </summary>
    [Table("BMS_BREED_MATERIAL_PIC")]
    public class BreedMaterialPicModel : BasePicModel
    {
        [Key]
        public int PicID { get; set; }

        public int? MaterialID { get; set; }
        [ForeignKey("MaterialID")]
        public BreedMaterialModel BreedMaterial { get; set; }
    }

    /// <summary>
    /// 养殖用药情况（视频）信息
    /// </summary>
    [Table("BMS_BREED_MATERIAL_VIDEO")]
    public class BreedMaterialVideoModel : BaseVideoModel
    {
        [Key]
        public int VideoID { get; set; }

        public int? MaterialID { get; set; }
        [ForeignKey("MaterialID")]
        public BreedMaterialModel BreedMaterial { get; set; }
    }
}
