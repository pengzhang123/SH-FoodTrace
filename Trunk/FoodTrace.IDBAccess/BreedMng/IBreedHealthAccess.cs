using FoodTrace.Model;
using System.Collections.Generic;

namespace FoodTrace.IDBAccess
{
    public interface IBreedHealthAccess : IBaseAccess<BreedHealthModel>
    {
        int GetEntityCount(int companyID, string name);
        List<BreedHealthModel> GetPagerBreedHealthByConditions(int companyID, string name, int pageIndex, int pageSize);
    }
}
