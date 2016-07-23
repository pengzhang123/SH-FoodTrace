using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodTrace.Model
{
    /// <summary>
    /// 屠宰场接收批次信息
    /// </summary>
    [Table("BMS_KILL_BATCH")]
    public class KillBatchModel : BaseModel
    {
        [Key]
        public int KillBatchID { get; set; }
        public int? CompanyID { get; set; }
        [ForeignKey("CompanyID")]
        public virtual CompanyModel Company { get; set; }

        public string BatchNO { get; set; }
        public string RecvicePeople { get; set; }
        public string Remark { get; set; }
        public bool? IsLocked { get; set; }
        public bool? IsShow { get; set; }

        public virtual ICollection<KillBatchDetailModel> KillBatchDetail { get; set; }
    }

    
}
