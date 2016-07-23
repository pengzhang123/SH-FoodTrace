using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodTrace.Model
{
    [Table("STM_MENU")]
    public class MenuModel : BaseModel
    {
        [Key]
        public int MenuID { get; set; }
        public int? ParentID { get; set; }
        public string Name { get; set; }
        public int? SortID { get; set; }
        public string IcoURL { get; set; }
        public string FunctionURL { get; set; }
        public bool? IsLocked { get; set; }
        public bool? IsShow { get; set; }
        public int? CreateID { get; set; }
        public string CreateName { get; set; }
        public DateTime? CreateTime { get; set; }
        public virtual ICollection<RoleModel> Role { get; set; }
    }
}
