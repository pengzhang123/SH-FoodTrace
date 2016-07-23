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
    /// 皮影加工对应的工序信息
    /// </summary>
    [Table("BMS_SHADOW_PROCESS")]
    public class ShadowProcessModel : BaseModel
    {
        [Key]
        public int SPIndex { get; set; }
        /// <summary>
        /// 工序ID
        /// </summary>
        public int? ProcessID { get; set; }
        [ForeignKey("ProcessID")]
        public virtual ProcessBaseModel ProcessBase { get; set; }

        /// <summary>
        /// 皮影ID
        /// </summary>
        public int? ShadowID { get; set; }
        [ForeignKey("ShadowID")]
        public virtual ShadowBaseModel ShadowBase { get; set; }

        /// <summary>
        /// 皮影加工厂ID
        /// </summary>
        public int? CompanyID { get; set; }
        [ForeignKey("CompanyID")]
        public virtual CompanyModel Company { get; set; }

        /// <summary>
        /// 加工批次
        /// </summary>
        public string ProcessBatch { get; set; }

        /// <summary>
        /// 工序代号
        /// </summary>
        public int ProcessCode { get; set; }

        /// <summary>
        /// 工序名称
        /// </summary>
        public string ProcessName { get; set; }

        /// <summary>
        /// 操作人
        /// </summary>
        public string WorkPeople { get; set; }

        /// <summary>
        /// 重量
        /// </summary>
        public double? Weight { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        public double? Price { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 排序号
        /// </summary>
        public int? SortID { get; set; }

        /// <summary>
        /// 是否锁定
        /// </summary>
        public bool? IsLocked { get; set; }

        /// <summary>
        /// 是否显示
        /// </summary>
        public bool? IsShow { get; set; }
    }
}
