using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.Model
{
    /// <summary>
    /// 冷链物流运输物品明细信息
    /// </summary>
    [Table("BMS_TRUN_APPLY_DETAIL")]
    public class TrunApplyDetailModel : BaseModel
    {
        [Key]
        public int DetailID { get; set; }
        public int? ApplyID { get; set; }
        [ForeignKey("ApplyID")]
        public virtual TrunApplyModel TrunApply { get; set; }
        public int? ProductID { get; set; }
        public string ProductName { get; set; }
        public string TrunEPC { get; set; }
        public string Remark { get; set; }
        public bool? IsLocked { get; set; }
        public bool? IsShow { get; set; }
    }
}
