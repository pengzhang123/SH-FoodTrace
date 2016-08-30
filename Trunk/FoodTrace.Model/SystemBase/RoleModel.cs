 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.Model
{
    [Table("STM_ROLE")]
    public class RoleModel : BaseModel
    {
        [Key]
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public string Remark { get; set; }
        public int? SortID { get; set; }
        public bool IsLocked { get; set; }
        public int? CreateID { get; set; }
        public string CreateName { get; set; }
        public DateTime? CreateTime { get; set; }
        
        public virtual ICollection<UserBaseModel> UserBase { get; set; }
        //public virtual ICollection<MenuModel> Menu { get; set; }
    }
}
