using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace FoodTrace.Model
{
    [Table("STM_USER_BASE")]
    public class UserBaseModel : BaseModel
    {
        [Key]
        public int UserID { get; set; }
        public string UserCode { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }

        public int? DeptID { get; set; }
        [ForeignKey("DeptID")]
        public virtual DeptModel Dept { get; set; }

        public int? CompanyID { get; set; }
        [ForeignKey("CompanyID")]
        public virtual CompanyModel Company { get; set; }

        public string AreaCode { get; set; }
        public int? Status { get; set; }
        public int? UserType { get; set; }
        public bool? IsLocked { get; set; }
        public int? CreateID { get; set; }
        public string CreateName { get; set; }
        public DateTime? CreateTime { get; set; }
        public virtual ICollection<LogUserLoginModel> LogUserLogin { get; set; }
        public virtual ICollection<RoleModel> Role { get; set; }
    }
}
