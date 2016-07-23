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
    /// 产品型号信息表
    /// </summary>
    [Table("BMS_PRODUCT_TYPE")]
    public class ProductTypeModel : BaseModel
    {
        [Key]
        public int ProductTypeID { get; set; }
        public string ProductTypeEN { get; set; }
        public string Remark { get; set; }
        public bool? IsLocked { get; set; }
        public bool? IsShow { get; set; }

        public virtual ICollection<ProductBaseModel> ProductBase { get; set; }
    }
}
