using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.Model.DtoModel
{
    public class KillBatchDto
    {
        public int KillBatchID { get; set; }
        public int? CompanyID { get; set; }

        public string CompanyName { get; set; }
        public string BatchNO { get; set; }
        public string RecvicePeople { get; set; }
        public string Remark { get; set; }
        public bool? IsLocked { get; set; }
        public bool? IsShow { get; set; }
    }
}
