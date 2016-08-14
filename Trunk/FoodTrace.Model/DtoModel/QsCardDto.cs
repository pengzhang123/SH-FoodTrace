using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.Model.DtoModel
{
    public class QsCardDto
    {
        public int QSID { get; set; }

        public int? CompanyID { get; set; }

        public string QSName { get; set; }
        public int? CheckType { get; set; }
        public string QSCard { get; set; }
        public DateTime? IssuingTime { get; set; }
        public string IssuingUnit { get; set; }
        public string Validity { get; set; }
        public string Attach { get; set; }
        public string Remark { get; set; }
        public bool? IsLocked { get; set; }
        public bool? IsShow { get; set; }
        public string CompanyName { get; set; }
    }
}
