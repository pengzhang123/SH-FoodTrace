using FoodTrace.Model;
using System.Collections.Generic;

namespace FoodTrace.IDBAccess
{
    public interface IBreedHealthPicAccess : IBaseAccess<BreedHealthPicModel>
    {
        int GetEntityCount(int companyID, string name);
        List<BreedHealthPicModel> GetPagerLandBlockByConditions(int companyID, string name, int pageIndex, int pageSize);
    }
}

