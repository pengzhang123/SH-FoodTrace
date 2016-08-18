using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.Model.DtoModel
{
    public class PlantDrugDto
    {
        public int DrugID { get; set; }

        public int? BatchID { get; set; }
        public string BatchNO { get; set; }
        public string People { get; set; }
        public string Object { get; set; }
        public string DrugName { get; set; }
        public DateTime? DrugTime { get; set; }
        public string Problem { get; set; }
        public string Method { get; set; }
        public string UANum { get; set; }
        public string Dilution { get; set; }
        public string Weather { get; set; }
        public string Pic { get; set; }
        public string PlansCode { get; set; }
        public string Remark { get; set; }
        public bool? IsLocked { get; set; }
        public bool? IsShow { get; set; }

    }
}
