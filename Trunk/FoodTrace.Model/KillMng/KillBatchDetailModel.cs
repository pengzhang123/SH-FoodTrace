using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodTrace.Model
{
    /// <summary>
    /// 屠宰场接收批次明细信息
    /// </summary>
    [Table("BMS_KILL_BATCH_DETAIL")]
    public class KillBatchDetailModel : BaseModel
    {
        [Key]
        public int DetailID { get; set; }
        public int? KillBatchID { get; set; }
        [ForeignKey("KillBatchID")]
        public virtual KillBatchModel KillBatch { get; set; }

        public int CultivationID { get; set; }
        [ForeignKey("CultivationID")]
        public virtual CultivationBaseModel CultivationBase { get; set; }

        public int? BreedID { get; set; }
        [ForeignKey("BreedID")]
        public virtual BreedBaseModel BreedBase { get; set; }

        public int? AreaID { get; set; }
        [ForeignKey("AreaID")]
        public virtual BreedAreaModel BreedArea { get; set; }

        public int? HomeID { get; set; }
        [ForeignKey("HomeID")]
        public virtual BreedHomeModel BreedHome { get; set; }

        public string CultivationEpc { get; set; }
        public string Remark { get; set; }
        public bool? IsLocked { get; set; }
        public bool? IsShow { get; set; }
    }
}
