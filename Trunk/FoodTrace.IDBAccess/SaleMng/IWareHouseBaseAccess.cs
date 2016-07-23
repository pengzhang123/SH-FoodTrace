using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IDBAccess
{
    /// <summary>
    /// 仓库基本信息管理
    /// </summary>
    public interface IWareHouseBaseAccess:IBaseAccess<WareHouseBaseModel>
    {
        int GetEntityCount(int companyID, string name);
        List<WareHouseBaseModel> GetPagerWareHouseBaseByConditions(int companyID, string name, int pageIndex, int pageSize);
    }
}
