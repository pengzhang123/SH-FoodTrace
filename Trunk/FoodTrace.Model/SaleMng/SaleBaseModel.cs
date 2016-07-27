using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.Model
{
    [Table("BMS_Sale_Base")]
    public class SaleBaseModel : BaseModel
    {
        [Key]
        public int SaleID { get; set; }
        public int? CompanyID { get; set; }
        [ForeignKey("CompanyID")]
        public virtual CompanyModel Company { get; set; }
        public string WareHouseEPC { get; set; }
        public string SaleEPC { get; set; }
        public string ORCode { get; set; }
        public string ChipCode { get; set; }
        public string ProductName { get; set; }
        public int? ClassID { get; set; }
        public string ClassName { get; set; }
        public string ProductCode { get; set; }
        public int? ProductSpcID { get; set; }
        [ForeignKey("ProductSpcID")]
        public virtual ProductSpecModel ProductSpec { get; set; }
        public int? ProductTypeID { get; set; }
        [ForeignKey("ProductTypeID")]
        public virtual ProductTypeModel ProductType { get; set; }
        public double? Weight { get; set; }
        public double? Price { get; set; }
        public string PinYingCode { get; set; }
        public DateTime? SaleTime { get; set; }
        public string Remark { get; set; }
        public bool? IsLocked { get; set; }
        public bool? IsShow { get; set; }
    }
}
