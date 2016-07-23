using FoodTrace.Model;
using System.Collections.Generic;

namespace FoodTrace.IDBAccess
{
    public interface ICultivationBaseAccess : IBaseAccess<CultivationBaseModel>
    {
        int GetEntityCount(int companyID, string name);
        List<CultivationBaseModel> GetPagerCultivationBaseByConditions(int companyID, string name, int pageIndex, int pageSize);
        CultivationBaseModel GetCultivationInfoByEPCOrORCode(string Epc, string OrCode);
    }
}
