using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.Model
{
    /// <summary>
    /// 产品规格信息
    /// </summary>
    [Table("BMS_PRODUCT_SPEC")]
    public class ProductSpecModel : BaseModel
    {
        [Key]
        public int SPCID { get; set; }
        public int? ClassID { get; set; }
        public string ClassName { get; set; }
        public string SpecCode { get; set; }
        public string SpecName { get; set; }
        public string Remark { get; set; }
        public bool? IsLocked { get; set; }
        public bool? IsShow { get; set; }

        public virtual ICollection<ProductBaseModel> ProductBase { get; set; }
    }
}
