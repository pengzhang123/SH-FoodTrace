using FoodTrace.Model;
using System.Collections.Generic;

namespace FoodTrace.IDBAccess
{
    public interface IPlansDrugAccess : IBaseAccess<PlansDrugModel>
    {
        int GetEntityCount(int companyID, string code);

        List<PlansDrugModel> GetPagerPlansDrugByConditions(int companyID, string code, int pageIndex, int pageSize);
    }
}
