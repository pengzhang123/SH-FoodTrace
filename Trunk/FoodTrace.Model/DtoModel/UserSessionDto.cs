using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.Model.DtoModel
{
    public class UserSessionDto
    {
        public int UserID { get; set; }

        public string UserCode { get; set; }
        public string UserName { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
    }
}
