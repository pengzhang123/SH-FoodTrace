using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IDBAccess
{
    public interface IProcessBatchDetailAccess : IBaseAccess<ProcessBatchDetailModel>
    {
        int GetEntityCount(int companyID, string code);
        List<ProcessBatchDetailModel> GetPagerProcessBatchDetailByConditions(int companyID, string code, int pageIndex, int pageSize);
    }
}
