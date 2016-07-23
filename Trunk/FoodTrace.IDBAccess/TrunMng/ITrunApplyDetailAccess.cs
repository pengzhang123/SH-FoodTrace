using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IDBAccess
{
    public interface ITrunApplyDetailAccess : IBaseAccess<TrunApplyDetailModel>
    {
        int GetEntityCount(int companyID, string applyNo);
        List<TrunApplyDetailModel> GetPagerTrunApplyDetailByConditions(int companyID, string applyNo, int pageIndex, int pageSize);
        TrunApplyDetailModel GetTrunApplyDetailByEPCOrORCode(string Epc, string OrCode);
    }
}
