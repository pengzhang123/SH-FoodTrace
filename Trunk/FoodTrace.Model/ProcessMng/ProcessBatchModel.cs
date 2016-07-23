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
    /// 加工厂接收待加工订单信息
    /// </summary>
    [Table("BMS_PROCESS_BATCH")]
    public class ProcessBatchModel : BaseModel
    {
        /// <summary>
        /// 加工接收订单编号
        /// </summary>
        [Key]
        public int PApplyID { get; set; }

        /// <summary>
        /// 公司id
        /// </summary>
        public int? CompanyID { get; set; }
        [ForeignKey("CompanyID")]
        public virtual CompanyModel Company { get; set; }
        /// <summary>
        /// 批次编号
        /// </summary>
        public string BatchNo { get; set; }

        /// <summary>
        /// 接收人
        /// </summary>
        public string RecvicePeople { get; set; }
        
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

        public virtual ICollection<ProcessBatchDetailModel> ProcessBatchDetail { get; set; }
    }
}
