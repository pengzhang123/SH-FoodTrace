using FoodTrace.Model;
using System.Collections.Generic;

namespace FoodTrace.IDBAccess
{
    public interface IBreedBaseAccess : IBaseAccess<BreedBaseModel>
    {
        int GetEntityCount(int companyID, string name);
        List<BreedBaseModel> GetPagerBreedBaseByConditions(int companyID, string name, int pageIndex, int pageSize);
        //BreedBaseModel GetBreedInfoByEPCOrORCode(string Epc, string OrCode);
    }
}
