using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IDBAccess
{
    public interface IKillCullAccess : IBaseAccess<KillCullModel>
    {
        int GetEntityCount(int companyID, string code);

        List<KillCullModel> GetPagerKillCullByConditions(int companyID, string code, int pageIndex, int pageSize);
        KillCullModel GetKillCullByEPCOrORCode(string Epc, string OrCode);
    }
}
