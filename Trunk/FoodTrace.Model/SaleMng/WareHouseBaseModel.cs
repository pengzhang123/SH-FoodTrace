using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.Model
{
    [Table("BMS_WareHouse_Base")]
    public class WareHouseBaseModel : BaseModel
    {
        [Key]
        public int WareHouseID { get; set; }
        public int? CompanyID { get; set; }
        [ForeignKey("CompanyID")]
        public virtual CompanyModel Company { get; set; }
        public string WareHouseCode { get; set; }
        public string WareHouseName { get; set; }
        public string AdminPeople { get; set; }
        public string WareHouseAddress { get; set; }
        public string WareHouseType { get; set; }
        public string ChargePeople { get; set; }
        public string Remark { get; set; }
        public bool IsLocked { get; set; }
        public bool IsShow { get; set; }
    }

}
