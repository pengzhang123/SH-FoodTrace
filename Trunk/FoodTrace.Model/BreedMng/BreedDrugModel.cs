using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodTrace.Model
{
    [Table("BMS_BREED_DRUG")]
    public class BreedDrugModel: BaseModel
    {
        [Key]
        public int DrugID { get; set; }
        public int? CultivationID { get; set; }
        [ForeignKey("CultivationID")]
        public virtual CultivationBaseModel CultivationBase { get; set; }
        public string CultivationEpc { get; set; }
        public string People { get; set; }
        public string Object { get; set; }
        public string DrugName { get; set; }
        public DateTime? DrugTime { get; set; }
        public string Problem { get; set; }
        public string Method { get; set; }
        public int? DrugCon { get; set; }
        public string Dilution { get; set; }
        public string Weather { get; set; }
        public string Pic { get; set; }
        public string Remark { get; set; }
        public bool? IsLocked { get; set; }
        public bool? IsShow { get; set; }
    }

    /// <summary>
    /// 养殖防疫（用药）图片
    /// </summary>
    [Table("BMS_BREED_DRUG_PIC")]
    public class BreedDrugPicModel : BasePicModel {
        [Key]
        public int PicID { get; set; }

        
        public int? DrugID { get; set; }
        [ForeignKey("DrugID")]
        public BreedDrugModel BreedDrug { get; set; }
    }

    /// <summary>
    /// 养殖用药情况(防疫情况)视频信息
    /// </summary>
    [Table("BMS_BREED_DRUG_VIDEO")]
    public class BreedDrugVideoModel : BaseVideoModel {
        [Key]
        public int VideoID { get; set; }

        public int? DrugID { get; set; }
        [ForeignKey("DrugID")]
        public BreedDrugModel BreedDrug { get; set; }
    }
}
