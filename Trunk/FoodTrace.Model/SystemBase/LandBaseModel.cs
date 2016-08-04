using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodTrace.Model
{
    /// <summary>
    /// 企业（种植）基地信息
    /// </summary>
    [Table("BMS_LAND_BASE")]
    public class LandBaseModel : BaseModel
    {
        [Key]
        public int LandID { get; set; }

        public int CompanyID { get; set; }
        //[ForeignKey("CompanyID")]
        //public virtual CompanyModel Company { get; set; }

        public string LandCode { get; set; }
        public string LandName { get; set; }
        public string Location { get; set; }
        public DateTime? LandTime { get; set; }
        public decimal? LandArea { get; set; }
        public int? EmployeesNum { get; set; }
        public int? LandState { get; set; }
        /// <summary>
        /// 1:种植,2:养殖
        /// </summary>
        public int? LandType { get; set; }
        public string Address { get; set; }
        public string Lon { get; set; }
        public string Lat { get; set; }
        public string Remark { get; set; }
        public bool? IsLocked { get; set; }
        public bool? IsShow { get; set; }
    }
}
