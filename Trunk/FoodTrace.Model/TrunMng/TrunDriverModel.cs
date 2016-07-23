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
    /// 冷链物流司机信息
    /// </summary>
    [Table("BMS_Trun_Driver")]
    public class TrunDriverModel : BaseModel
    {
        [Key]
        public int DriverID { get; set; }
        public int? CompanyID { get; set; }
        [ForeignKey("CompanyID")]
        public virtual CompanyModel Company { get; set; }
        public string DriverEPC { get; set; }
        public string DriverName { get; set; }
        public string Tel { get; set; }
        public int? Age { get; set; }
        public string Address { get; set; }
        public string Remark { get; set; }
        public bool? IsLocked { get; set; }
        public bool? IsShow { get; set; }
    }
}
