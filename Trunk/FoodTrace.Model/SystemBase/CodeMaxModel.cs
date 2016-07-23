using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodTrace.Model
{
    [Table("STM_CodeMax")]
    public class CodeMaxModel : BaseModel
    {
        [Key]
        public int CodeMaxID { get; set; }
        public string ObjectCode { get; set; }
        public string ObjectName { get; set; }
        public string ObjectValue { get; set; }
        public int SortID { get; set; }
        public string Remark { get; set; }
        public bool IsLocked { get; set; }
        public bool IsShow { get; set; }
    }
}
