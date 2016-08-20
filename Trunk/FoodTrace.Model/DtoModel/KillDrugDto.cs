using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.Model.DtoModel
{
    public class KillDrugDto
    {
        public int DrugID { get; set; }

        public int? KillCullID { get; set; }

        public string KillEpc { get; set; }
        public string People { get; set; }
        public DateTime? DrugTime { get; set; }
        public bool? IsNormal { get; set; }

        public string DrugStatus { get { return IsNormal == true ? "是" : "否"; } }
        public string Pic { get; set; }
        public string Remark { get; set; }
        public bool? IsLocked { get; set; }
        public bool? IsShow { get; set; }
    }
}
