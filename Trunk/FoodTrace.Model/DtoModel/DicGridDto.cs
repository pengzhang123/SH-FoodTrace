using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.Model.DtoModel
{
    public class DicGridDto
    {
        public int DicID { get; set; }

        public int? RootID { get; set; }
        //[ForeignKey("RootID")]
        //public virtual DicRootModel DicRoot { get; set; }

        public string ParentName { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
