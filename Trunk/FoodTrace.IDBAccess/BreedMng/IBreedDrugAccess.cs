using FoodTrace.Model;
using System.Collections.Generic;

namespace FoodTrace.IDBAccess
{
    public interface IBreedDrugAccess : IBaseAccess<BreedDrugModel>
    {
        int GetEntityCount(int companyID, string name);
        List<BreedDrugModel> GetPagerBreedDrugByConditions(int companyID, string name, int pageIndex, int pageSize);
    }
}
