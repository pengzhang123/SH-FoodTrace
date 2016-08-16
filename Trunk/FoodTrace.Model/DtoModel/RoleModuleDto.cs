using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.Model.DtoModel
{
    public class RoleModuleDto
    {
        public RoleModuleDto()
        {
            RoleMenu=new List<RoleMenuDto>();
        }
        public string ModuleName { get; set; }

        public string ModuleIco { get; set; }

        public int? Sort { get; set; }

        public IEnumerable<RoleMenuDto> RoleMenu { get; set; } 
    }

    public class RoleMenuDto
    {
        public string MenuName { get; set; }

        public string MenuIcon { get; set; }

        public string MenuUrl { get; set; }
        public int? Sort { get; set; }
    }
}
