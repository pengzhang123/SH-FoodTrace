using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IDBAccess
{
    public interface IShadowBaseAccess : IBaseAccess<ShadowBaseModel>
    {
        int GetEntityCount(int companyID, string code);
        List<ShadowBaseModel> GetPagerShadowBaseByConditions(int companyID, string code, int pageIndex, int pageSize);
        ShadowBaseModel GetShawInfoByEPCOrORCode(string Epc, string OrCode);
        ShadowBaseModel GetShawInfoByChipCode(string chipCode);
    }
}
