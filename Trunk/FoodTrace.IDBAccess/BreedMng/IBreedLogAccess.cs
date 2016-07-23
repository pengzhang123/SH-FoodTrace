using FoodTrace.Model;
using System.Collections.Generic;

namespace FoodTrace.IDBAccess
{
    public interface IBreedLogAccess : IBaseAccess<BreedLogModel>
    {
        int GetEntityCount(int companyID, string name);
        List<BreedLogModel> GetPagerLandBlockByConditions(int companyID, string name, int pageIndex, int pageSize);
    }
}

