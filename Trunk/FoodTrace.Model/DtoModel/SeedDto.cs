using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.Model.DtoModel
{
    public class SeedDto
    {
        public int SeedID { get; set; }
        public string SeedCode { get; set; }
        public string SeedNO { get; set; }
        public string SeedName { get; set; }
        public string BatchNO { get; set; }
        public string Place { get; set; }
        public string Supplier { get; set; }
        public string PurchPerson { get; set; }
        public DateTime? BuyTime { get; set; }
        public decimal? BuyCount { get; set; }
        public string Units { get; set; }
        public string Remark { get; set; }
        public bool? IsLocked { get; set; }
        public bool? IsShow { get; set; }
    }
}
