using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.Model
{
    public class DeptDto
    {
        public  int  DeptID { get; set; }
        public int? CompanyId { get; set; }
        public string  CompanyName { get; set; }
        public string  DeptName { get; set; }
        public string UpperDeptName { get; set; }
        public string   DeptRemark { get; set; }
        public int?  SortID { get; set; }
    }
}
