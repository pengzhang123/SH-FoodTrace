using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.Model
{
    [Table("STM_ROLE_MENU_INDEX")]
    public class RoleMenuModel : BaseModel
    {
        [Key]
        public int RMID { get; set; }

        public int? RoleID { get; set; }
        [ForeignKey("RoleID")]
        public virtual RoleModel Role { get; set; }

        public int? MenuID { get; set; }
        [ForeignKey("MenuID")]
        public virtual MenuModel Menu { get; set; }

        public int? CreateID { get; set; }
        public string CreateName { get; set; }
        public DateTime? CreateTime { get; set; }
    }
}
