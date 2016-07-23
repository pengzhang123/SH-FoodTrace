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
    /// 成品皮影加工基本信息
    /// </summary>
    [Table("BMS_SHADOW_BASE")]
    public class ShadowBaseModel : BaseModel
    {
        /// <summary>
        /// 皮影ID
        /// </summary>
        [Key]
        public int ShadowID { get; set; }

        /// <summary>
        /// 皮影加工厂ID
        /// </summary>
        public int? CompanyID { get; set; }
        [ForeignKey("CompanyID")]
        public virtual CompanyModel Company { get; set; }

        /// <summary>
        /// 产品ID
        /// </summary>
        public int? ProductID { get; set; }
        [ForeignKey("ProductID")]
        public virtual ProductBaseModel Product { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 产品号型
        /// </summary>
        public int? ProductTypeID { get; set; }
        [ForeignKey("ProductTypeID")]
        public virtual ProductTypeModel ProductType { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        public double? Price { get; set; }

        /// <summary>
        /// 产品代号
        /// </summary>
        public string ProductCode { get; set; }

        /// <summary>
        /// 皮影溯源码
        /// </summary>
        public string ShadowEPC { get; set; }

        /// <summary>
        /// 二唯码
        /// </summary>
        public string ORCode { get; set; }

        /// <summary>
        /// 芯片码
        /// </summary>
        public string ChipCode { get; set; }

        /// <summary>
        /// 加工批次
        /// </summary>
        public string ProcessBatch { get; set; }

        /// <summary>
        /// 加工方法
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// 加工时间
        /// </summary>
        public DateTime? ProcessTime { get; set; }

        /// <summary>
        /// 温度指标
        /// </summary>
        public string Temp { get; set; }

        /// <summary>
        /// 干燥指标
        /// </summary>
        public string Dry { get; set; }

        /// <summary>
        /// 干燥时间
        /// </summary>
        public DateTime? DryTime { get; set; }

        /// <summary>
        /// 原料批次
        /// </summary>
        public string RawBatch { get; set; }

        /// <summary>
        /// 皮影工艺流程
        /// </summary>
        public string Flow { get; set; }

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

        public virtual ICollection<ShadowProcessModel> ShadowProcess { get; set; }
    }
}
