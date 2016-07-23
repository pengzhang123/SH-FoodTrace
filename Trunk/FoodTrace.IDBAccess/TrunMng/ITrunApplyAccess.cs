using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IDBAccess
{
    public interface ITrunApplyAccess : IBaseAccess<TrunApplyModel>
    {
        int GetEntityCount(int companyID, string applyNo);
        List<TrunApplyModel> GetPagerTrunApplyByConditions(int companyID, string applyNo, int pageIndex, int pageSize);
    }
}
