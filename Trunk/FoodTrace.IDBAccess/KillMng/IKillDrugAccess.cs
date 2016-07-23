using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IDBAccess
{
    public interface IKillDrugAccess : IBaseAccess<KillDrugModel>
    {
        int GetEntityCount(int companyID, string code);

        List<KillDrugModel> GetPagerKillDrugByConditions(int companyID, string code, int pageIndex, int pageSize);
    }
}
