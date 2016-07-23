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
    /// 冷链物流运输订单信息
    /// </summary>
    [Table("BMS_Trun_Apply")]
    public class TrunApplyModel : BaseModel
    {
        [Key]
        public int ApplyID { get; set; }
        public int? CompanyID { get; set; }
        [ForeignKey("CompanyID")]
        public virtual CompanyModel Company { get; set; }
        public int? VehicleID { get; set; }
        [ForeignKey("VehicleID")]
        public virtual TrunVehicleModel TrunVehicle { get; set; }
        public int? DriverID { get; set; }
        [ForeignKey("DriverID")]
        public virtual TrunDriverModel TrunDriver { get; set; }
        public string ApplyNo { get; set; }
        public string MaxTemp { get; set; }
        public string MinTemp { get; set; }
        public string MaxWet { get; set; }
        public string MinWet { get; set; }
        public DateTime? StartTime { get; set; }
        public string StartAddress { get; set; }
        public DateTime? EndTime { get; set; }
        public string EndAddress { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Remark { get; set; }
        public bool? IsLocked { get; set; }
        public bool? IsShow { get; set; }

        public virtual ICollection<TrunApplyDetailModel> TrunApplyDetail { get; set; }
        public virtual ICollection<TrunTemperatrueModel> TrunTemperatrue { get; set; }
    }
}
