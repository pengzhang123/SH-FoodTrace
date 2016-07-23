using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.Model
{
    [Table("BMS_Trun_Temperature")]
    public class TrunTemperatrueModel : BaseModel
    {
        [Key]
        public int TemperatureID { get; set; }
        public int? ApplyID { get; set; }
        [ForeignKey("ApplyID")]
        public virtual TrunApplyModel TrunApply { get; set; }
        public DateTime? PickTime { get; set; }
        public double? Temperature { get; set; }
        public string Lon { get; set; }
        public string Lat { get; set; }
        public string Remark { get; set; }
        public bool? IsLocked { get; set; }
        public bool? IsShow { get; set; }

    }
}
