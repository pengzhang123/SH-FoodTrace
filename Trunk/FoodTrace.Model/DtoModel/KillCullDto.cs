using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.Model.DtoModel
{
    public class KillCullDto
    {
        public int KillCullID { get; set; }

        public int? CompanyID { get; set; }

        public string CompanyName { get; set; }
        public int? KillBatchID { get; set; }

        public string KillBatchNO { get; set; }
        public int CultivationID { get; set; }
        public string CultivationEpc { get; set; }
        public string KillEpc { get; set; }
        public int? ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal? Weight { get; set; }
        public string Flow { get; set; }
        public DateTime? KillTime { get; set; }
        public string Remark { get; set; }
        public bool? IsLocked { get; set; }
        public bool? IsShow { get; set; }
    }
}
