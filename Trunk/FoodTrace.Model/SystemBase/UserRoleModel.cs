using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.Model
{
    [Table("STM_User_Role_Index")]
    public class UserRoleModel : BaseModel
    {
        [Key]
        public int URDID { get; set; }

        public int? UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual UserBaseModel UserBase { get; set; }

        public int? RoleID { get; set; }
        [ForeignKey("RoleID")]
        public virtual RoleModel Role { get; set; }

        public int? CreateID { get; set; }
        public DateTime? CreateTime { get; set; }
    }
}
