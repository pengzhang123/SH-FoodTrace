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
    /// 加工厂加工产品信息
    /// </summary>
    [Table("BMS_PROCESS_PRODUCT")]
    public class ProcessProductModel : BaseModel
    {
        /// <summary>
        /// 加工编号
        /// </summary>
        [Key]
        public int PProductID { get; set; }

        /// <summary>
        /// 明细编号
        /// </summary>
        public int? DetailID { get; set; }
        [ForeignKey("DetailID")]
        public ProcessBatchDetailModel ProcessBatchDetail { get; set; }

        /// <summary>
        /// 产品ID
        /// </summary>
        public int? ProductID { get; set; }
        [ForeignKey("ProductID")]
        public ProductBaseModel ProductBase { get; set; }

        /// <summary>
        /// 记录人
        /// </summary>
        public string People { get; set; }

        /// <summary>
        /// 待加工溯源码
        /// </summary>
        public string ProcessEPC { get; set; }

        /// <summary>
        /// 产品类别
        /// </summary>
        public string ClassID { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 产品号型
        /// </summary>
        public string ProductTypeName { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        public double? Price { get; set; }

        /// <summary>
        /// 产品代号
        /// </summary>
        public string ProductCode { get; set; }

        /// <summary>
        /// 加工溯源码
        /// </summary>
        public string ShadowEPC { get; set; }

        /// <summary>
        /// 二唯码
        /// </summary>
        public string OrCode { get; set; }

        /// <summary>
        /// 芯片码
        /// </summary>
        public string ChipCode { get; set; }

        /// <summary>
        /// 产品登记
        /// </summary>
        public string Level { get; set; }

        /// <summary>
        /// 批行标准
        /// </summary>
        public string ISO { get; set; }

        /// <summary>
        /// 产品信息
        /// </summary>
        public string Info { get; set; }

        /// <summary>
        /// 加工批次
        /// </summary>
        public string ProcessBatch { get; set; }

        /// <summary>
        /// 单位重量
        /// </summary>
        public string Weight { get; set; }

        /// <summary>
        /// 包装规则
        /// </summary>
        public string Package { get; set; }

        /// <summary>
        /// 包装前工艺流程
        /// </summary>
        public string Flow { get; set; }

        /// <summary>
        /// 包装数量
        /// </summary>
        public string PackgeNum { get; set; }

        /// <summary>
        /// 包装日期
        /// </summary>
        public DateTime? PackageTime { get; set; }

        /// <summary>
        /// 保质期
        /// </summary>
        public string Life { get; set; }

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
    }
}
