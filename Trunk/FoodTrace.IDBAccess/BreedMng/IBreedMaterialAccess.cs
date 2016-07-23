using FoodTrace.Model;
using System.Collections.Generic;

namespace FoodTrace.IDBAccess
{
    public interface IBreedMaterialAccess : IBaseAccess<BreedMaterialModel>
    {
        int GetEntityCount(int companyID, string name);
        List<BreedMaterialModel> GetPagerBreedMaterialByConditions(int companyID, string name, int pageIndex, int pageSize);
    }
}

