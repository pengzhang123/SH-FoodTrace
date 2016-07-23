using FoodTrace.Model;
using System.Collections.Generic;

namespace FoodTrace.IDBAccess
{
    public interface ILandBaseAccess : IBaseAccess<LandBaseModel>
    {
        int GetEntityCount(int companyID, string name);

        List<LandBaseModel> GetPagerLandBaseByConditions(int companyID, string name, int pageIndex, int pageSize);
    }
}
