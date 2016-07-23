using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodTrace.Model
{
    [Table("STM_AREAPLAT")]
    public class AreaPlatModel : BaseModel
    {
        [Key]
        public int AreaID { get; set; }
        public string AreaCode { get; set; }
        public string AreaName { get; set; }
        public string Remark { get; set; }
    }
}
