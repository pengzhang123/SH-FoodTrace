using FoodTrace.Model;
using System.Collections.Generic;

namespace FoodTrace.IDBAccess
{
    public interface IVarietyBaseAccess : IBaseAccess<VarietyBaseModel>
    {
        int GetEntityCount(int companyID, string name);
        List<VarietyBaseModel> GetPagerVarietyBaseByConditions(int companyID, string name, int pageIndex, int pageSize);
    }
}

