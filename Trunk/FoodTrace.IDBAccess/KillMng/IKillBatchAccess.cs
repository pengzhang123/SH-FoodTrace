using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IDBAccess
{
    public interface IKillBatchAccess : IBaseAccess<KillBatchModel>
    {
        int GetEntityCount(int companyID, string code);

        List<KillBatchModel> GetPagerKillBatchByConditions(int companyID,string code, int pageIndex, int pageSize);
    }
}
