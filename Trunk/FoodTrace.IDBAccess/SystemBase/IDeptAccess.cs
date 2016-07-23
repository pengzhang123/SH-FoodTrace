using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IDBAccess
{
    public interface IDeptAccess : IBaseAccess<DeptModel>
    {
        int GetEntityCount(int companyID, string name);

        List<DeptModel> GetPagerDeptByConditions(string name, int pageIndex, int pageSize,int? companyID);
    }
}
