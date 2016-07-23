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
    /// 商品/产品基本信息表
    /// </summary>
    [Table("BMS_PRODUCT_BASE")]
    public class ProductBaseModel : BaseModel
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int? ClassID { get; set; }
        public string ClassName { get; set; }
        public string ProductCode { get; set; }
        public int? ProductSpcID { get; set; }
        [ForeignKey("ProductSpcID")]
        public virtual ProductSpecModel ProductSpec { get;set;}

        public int? ProductTypeID { get; set; }
        [ForeignKey("ProductTypeID")]
        public virtual ProductTypeModel ProductType { get; set; }
        public Double? Weight { get; set; }
        public string PinYinCode { get; set; }
        public Double? Price { get; set; }
        public string Remark { get; set; }
        public bool? IsLocked { get; set; }
        public bool? IsShow { get; set; }

    }
}
