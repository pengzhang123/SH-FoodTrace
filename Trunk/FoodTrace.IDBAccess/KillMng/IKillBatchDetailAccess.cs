using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IDBAccess
{
    public interface IKillBatchDetailAccess : IBaseAccess<KillBatchDetailModel>
    {
        int GetEntityCount(int companyID, string code);

        List<KillBatchDetailModel> GetPagerKillBatchDetailByConditions(int companyID, string code, int pageIndex, int pageSize);

        List<KillBatchDetailModel> GetAllEntities(int batchId);
    }
}
