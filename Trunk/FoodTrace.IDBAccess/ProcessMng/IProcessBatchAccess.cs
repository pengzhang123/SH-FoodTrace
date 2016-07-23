using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IDBAccess
{
    public interface IProcessBatchAccess : IBaseAccess<ProcessBatchModel>
    {
        int GetEntityCount(int companyID, string batchNo);
        List<ProcessBatchModel> GetPagerProcessBatchByConditions(int companyID, string batchNo, int pageIndex, int pageSize);
    }
}
