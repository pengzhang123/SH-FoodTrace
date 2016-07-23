using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodTrace.Model
{
    [Table("BMS_TID")]
    public class TIDModel : BaseModel
    {
        [Key]
        public int TID{ get; set; }
        public int? CompanyID { get; set; }
        [ForeignKey("CompanyID")]
        public virtual CompanyModel Company { get; set; }
        public string ChipCode { get; set; }
        public string Epc { get; set; }
        public string CheckCode { get; set; }
        public bool IsUse { get; set; }
        public string Remark { get; set; }
        public bool? IsLocked { get; set; }
        public bool? IsShow { get; set; }
    }
}
