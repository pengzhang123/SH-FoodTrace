using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.Model
{
    [Table("BMS_WareHouse_Stock")]
    public class WareHouseStockModel:BaseModel
    {
        [Key]
        public int StockID { get; set; }
        public int? ProductID { get; set; }
        [ForeignKey("ProductID")]
        public virtual ProductBaseModel ProductBase { get; set; }
        public int? WareHouseID { get; set; }
        [ForeignKey("WareHouseID")]
        public virtual WareHouseBaseModel WareHouseBase { get; set; }
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
        public double Weight { get; set; }
        public string PinYingCode { get; set; }
        public int StockCount { get; set; }
        public int TotalCount { get; set; }
        public int UseCount { get; set; }
        public int FreezeCount { get; set; }
        public string Remark { get; set; }
        public bool IsLocked { get; set; }
        public bool IsShow { get; set; }
    }
}
