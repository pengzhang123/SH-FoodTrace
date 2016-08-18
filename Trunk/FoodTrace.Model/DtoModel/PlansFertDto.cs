using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.Model.DtoModel
{
   public class PlansFertDto
    {
        public int FertID { get; set; }

        public int? BatchID { get; set; }

        public string BatchName { get; set; }
        public string FertCode { get; set; }
        public string FertName { get; set; }
        public string FertPeople { get; set; }
        public DateTime? FertTime { get; set; }
        public string FertType { get; set; }
        public string FertMethod { get; set; }
        public string UANum { get; set; }
        public string Weather { get; set; }
        public string Pic { get; set; }
        public string PlansCode { get; set; }
        public string Remark { get; set; }
        public bool? IsLocked { get; set; }
        public bool? IsShow { get; set; }
    }
}
