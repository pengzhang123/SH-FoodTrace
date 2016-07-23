using FoodTrace.Model;
using System.Collections.Generic;

namespace FoodTrace.IDBAccess
{
    public interface IPlansFertAccess : IBaseAccess<PlansFertModel>
    {
        int GetEntityCount(int companyID, string code);

        List<PlansFertModel> GetPagerPlansFertByConditions(int companyID, string code, int pageIndex, int pageSize);
    }
}
