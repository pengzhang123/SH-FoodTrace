using FoodTrace.Model;
using System.Collections.Generic;

namespace FoodTrace.IDBAccess
{
    public interface IBreedHomeAccess : IBaseAccess<BreedHomeModel>
    {
        int GetEntityCount(int companyID, string name);
        List<BreedHomeModel> GetPagerBreedHomeByConditions(int companyID, string name, int pageIndex, int pageSize);
    }
}

