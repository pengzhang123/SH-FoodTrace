using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodTrace.Model
{
    /// <summary>
    /// 系统部门信息
    /// </summary>
    [Table("STM_DEPT")]
    public class DeptModel : BaseModel
    {
        public DeptModel()
        {
            UserBase = new List<UserBaseModel>();
        }
        [Key]
        public int DeptID { get; set; }

        public int? CompanyID { get; set; }
        [ForeignKey("CompanyID")]
        public virtual CompanyModel Company { get; set; }

        public string DeptName { get; set; }
        public int? UpperDeptID { get; set; }
        [ForeignKey("UpperDeptID")]
        public virtual DeptModel UpperDept { get; set; }
        public string DeptRemark { get; set; }
        public int? SortID { get; set; }

        public virtual ICollection<UserBaseModel> UserBase { get; set; }
    }
}
