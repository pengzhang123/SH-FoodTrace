using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodTrace.Model
{
    [Table("STM_CodeObject")]
    public class CodeObjectModel : BaseModel
    {
        [Key]
        public int ObjectID { get; set;}
        public string ObjectCode { get; set; }
        public string ObjectName { get; set; }
        public string Prefix { get; set; }
        public int MaxLength { get; set; }
        public int SeqLength { get; set; }
        public bool IsFixedLength { get; set; }
        public bool IsAuto { get; set; }
        public int SortID { get; set; }
        public string Remark { get; set; }
        public bool IsLocked { get; set; }
        public bool IsShow { get; set; }
    }
}
