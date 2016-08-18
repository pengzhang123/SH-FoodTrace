using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.Model.DtoModel
{
    public class PlatPlanDto
    {

        public int BatchID { get; set; }

        public int? BlockID { get; set; }

        public string BlockName { get; set; }
        public int? SeedID { get; set; }
        public string SeedName { get; set; }
        public string BatchNO { get; set; }
        public string BatchCode { get; set; }
        public DateTime? PlansTime { get; set; }
        public string PlansYear { get; set; }
        public DateTime? HarvestTime { get; set; }
        public decimal? PlansArea { get; set; }
        public string ChargePerson { get; set; }
        public decimal? HarvestCount { get; set; }
        public decimal? RealCount { get; set; }
        public string People { get; set; }
        public string Remark { get; set; }
        public bool? IsLocked { get; set; }
        public bool? IsShow { get; set; }
    }
}
