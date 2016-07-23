using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodTrace.Model
{
    /// <summary>
    /// 待屠宰转换信息
    /// </summary>
    [Table("BMS_KILL_CULL")]
    public class KillCullModel : BaseModel
    {
        [Key]
        public int KillCullID { get; set; }

        public int? CompanyID { get; set; }
        [ForeignKey("CompanyID")]
        public virtual CompanyModel Company {get;set; }

        public int? KillBatchID { get; set; }
        [ForeignKey("KillBatchID")]
        public virtual KillBatchModel KillBatch { get; set; }

        public int CultivationID { get; set; }
        public string CultivationEpc { get; set; }
        public string KillEpc { get; set; }
        public int? ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal? Weight { get; set; }
        public string Flow { get; set; }
        public DateTime? KillTime { get; set; }
        public string Remark { get; set; }
        public bool? IsLocked { get; set; }
        public bool? IsShow { get; set; }
    }
}
