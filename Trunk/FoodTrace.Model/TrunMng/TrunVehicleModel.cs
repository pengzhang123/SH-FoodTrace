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
    /// 冷链物流车辆信息
    /// </summary>
    [Table("BMS_Trun_Vehicle")]
    public class TrunVehicleModel : BaseModel
    {
        [Key]
        public int VehicleID { get; set; }
        public int? CompanyID { get; set; }
        [ForeignKey("CompanyID")]
        public virtual CompanyModel Company { get; set; }
        public string CarNo { get; set; }
        public string CarCode { get; set; }
        public string CarSize { get; set; }
        public string MaxTemp { get; set; }
        public string MinTemp { get; set; }
        public string MaxWet { get; set; }
        public string MinWet { get; set; }
        public string Remark { get; set; }
        public bool? IsLocked { get; set; }
        public bool? IsShow { get; set; }
    }
}
