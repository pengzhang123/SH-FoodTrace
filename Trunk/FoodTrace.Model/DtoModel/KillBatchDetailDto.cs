using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.Model.DtoModel
{
    public class KillBatchDetailDto
    {
        public int DetailID { get; set; }
        public int? KillBatchID { get; set; }

        public int CultivationID { get; set; }
        public int? BreedID { get; set; }
        public int? AreaID { get; set; }

        public int? HomeID { get; set; }
 
        public string CultivationEpc { get; set; }
        public string Remark { get; set; }
        public bool? IsLocked { get; set; }
        public bool? IsShow { get; set; }
    }
}
