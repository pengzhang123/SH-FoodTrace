using FoodTrace.Model;
using System.Collections.Generic;

namespace FoodTrace.IDBAccess
{
    public interface IBreedAreaAccess : IBaseAccess<BreedAreaModel>
    {
        List<BreedAreaModel> GetPagerBreedAreaByConditions(int companyID, string name, int pageIndex, int pageSize);
        int GetEntityCount(int companyID, string name);
    }
}
