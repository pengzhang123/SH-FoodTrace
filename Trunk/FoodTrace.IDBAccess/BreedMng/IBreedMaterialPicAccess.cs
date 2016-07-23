using FoodTrace.Model;
using System.Collections.Generic;

namespace FoodTrace.IDBAccess
{
    public interface IBreedMaterialPicAccess : IBaseAccess<BreedMaterialPicModel>
    {
        int GetEntityCount(int companyID, string name);
        List<BreedMaterialPicModel> GetPagerLandBlockByConditions(int companyID, string name, int pageIndex, int pageSize);
    }
}
