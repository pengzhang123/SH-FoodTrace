using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodTrace.Model
{
    [Table("STM_DICROOT")]
    public class DicRootModel : BaseModel
    {
        [Key]
        public int RootID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? SortID { get; set; }
        public bool? IsLocked { get; set; }
        public virtual ICollection<DicModel> Dic { get; set; }
    }

    [Table("STM_DIC")]
    public class DicModel : BaseModel
    {
        [Key]
        public int DicID { get; set; }

        public int? RootID { get; set; }
        [ForeignKey("RootID")]
        public virtual DicRootModel DicRoot { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? SortID { get; set; }
        public bool? IsLocked { get; set; }
    }
}
