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
    /// 加工厂接收的加工明细信息
    /// </summary>
    [Table("BMS_PROCESS_BATCH_DETAIL")]
    public class ProcessBatchDetailModel : BaseModel
    {
        /// <summary>
        /// 明细编号
        /// </summary>
        [Key]
        public int DetailID { get; set; }

        /// <summary>
        /// 加工接收订单编号
        /// </summary>
        public int? PApplyID { get; set; }
        [ForeignKey("PApplyID")]
        public virtual ProcessBatchModel ProcessBatch { get; set; }
        /// <summary>
        /// 加工接收类型
        /// </summary>
        public int? RecvType { get; set; }

        /// <summary>
        /// 待加工溯源码
        /// </summary>
        public string ProcessEPC { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 重量
        /// </summary>
        public double? Weight { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 是否锁定
        /// </summary>
        public bool? IsLocked { get; set; }

        /// <summary>
        /// 是否显示
        /// </summary>
        public bool? IsShow { get; set; }

        public virtual ICollection<ProcessProductModel> ProcessProduct { get; set; }
    }
}
