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
    /// 生产加工工序基本信息
    /// </summary>
    [Table("BMS_PROCESS_BASE")]
    public class ProcessBaseModel : BaseModel
    {
        /// <summary>
        /// 工序ID
        /// </summary>
        [Key]
        public int ProcessID { get; set; }

        /// <summary>
        /// 工序分类
        /// </summary>
        public int? ProcessClass { get; set; }

        /// <summary>
        /// 工序代号
        /// </summary>
        public int ProcessCode { get; set; }

        /// <summary>
        /// 工序名称
        /// </summary>
        public string ProcessName { get; set; }

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

        public virtual ICollection<ShadowProcessModel> ShadowProcess { get; set; }
    }
}
