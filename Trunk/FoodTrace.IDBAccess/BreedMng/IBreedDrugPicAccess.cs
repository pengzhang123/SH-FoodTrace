using FoodTrace.Model;
using System.Collections.Generic;

namespace FoodTrace.IDBAccess
{
    public interface IBreedDrugPicAccess : IBaseAccess<BreedDrugPicModel>
    {
        int GetEntityCount(int companyID, string name);
        List<BreedDrugPicModel> GetPagerLandBlockByConditions(int companyID, string name, int pageIndex, int pageSize);
    }
}
