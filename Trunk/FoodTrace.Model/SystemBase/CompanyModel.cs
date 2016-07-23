using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodTrace.Model
{
    [Table("STM_COMPANY")]
    public class CompanyModel : BaseModel
    {
        [Key]
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string AreaCode { get; set; }
        public string Address { get; set; }
        public string Leader { get; set; }
        public string Logo { get; set; }
        public string OrgID { get; set; }
        public string QsCode { get; set; }
        public string Location { get; set; }
        public string Code { get; set; }
        public string ZipCode { get; set; }
        public string TaxCard { get; set; }
        public string Fax { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Info { get; set; }
        public string Demand { get; set; }
        public string Remark { get; set; }
        public bool? IsLocked { get; set; }
        public bool? IsShow { get; set; }

        public virtual ICollection<LandBaseModel> LandBase { get; set; }
        public virtual ICollection<DeptModel> Dept { get; set; }
    }
}
