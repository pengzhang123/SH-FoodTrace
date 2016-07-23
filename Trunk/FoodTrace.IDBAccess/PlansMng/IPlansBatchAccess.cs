using FoodTrace.Model;
using System.Collections.Generic;

namespace FoodTrace.IDBAccess
{
    public interface IPlansBatchAccess : IBaseAccess<PlansBatchModel>
    {
        int GetEntityCount(int companyID, string code);

        List<PlansBatchModel> GetPagerPlansBatchByConditions(int companyID, string code, int pageIndex, int pageSize);
        PlansBatchModel GetPlansBatchByEPCOrORCode(string Epc, string OrCode);
    }
}
