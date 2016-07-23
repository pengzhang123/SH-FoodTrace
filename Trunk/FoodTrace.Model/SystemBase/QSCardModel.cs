using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodTrace.Model
{
    /// <summary>
    /// 企业资质
    /// </summary>
    [Table("BMS_QSCARD")]
    public class QSCardModel:BaseModel
    {
        [Key]
        public int QSID { get; set; }
        
        public int? CompanyID { get; set; }
        [ForeignKey("CompanyID")]
        public virtual CompanyModel Company { get; set; }
        public string QSName { get; set; }
        public int? CheckType { get; set; }
        public string QSCard { get; set; }
        public DateTime? IssuingTime { get; set; }
        public string IssuingUnit { get; set; }
        public string Validity { get; set; }
        public string Attach { get; set; }
        public string Remark { get; set; }
        public bool? IsLocked { get; set; }
        public bool? IsShow { get; set; }
    }
}
