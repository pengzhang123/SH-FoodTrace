using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IDBAccess
{
    public interface IProcessProductAccess : IBaseAccess<ProcessProductModel>
    {
        int GetEntityCount(int companyID, string code);
        List<ProcessProductModel> GetPagerProcessProductByConditions(int companyID, string applyNo, int pageIndex, int pageSize);
        ProcessProductModel GetProcessProductByEPCOrORCode(string Epc, string OrCode);
    }
}
