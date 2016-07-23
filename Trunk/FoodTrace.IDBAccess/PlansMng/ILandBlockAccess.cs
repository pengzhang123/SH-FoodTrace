using FoodTrace.Model;
using System.Collections.Generic;
using System.Linq;

namespace FoodTrace.IDBAccess
{
    /// <summary>
    /// 种植企业基地地块管理
    /// </summary>
    public interface ILandBlockAccess : IBaseAccess<LandBlockModel>
    {
        int GetEntityCount(int companyID, string name);

        List<LandBlockModel> GetPagerLandBlockByConditions(int companyID, string name, int pageIndex, int pageSize);

        //IQueryable<LandBlockModel> GetAllEntities1();
    }
}
