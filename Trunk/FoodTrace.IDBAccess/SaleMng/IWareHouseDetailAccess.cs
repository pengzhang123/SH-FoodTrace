using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IDBAccess
{
    /// <summary>
    /// 仓库详细信息管理
    /// </summary>
    public interface IWareHouseDetailAccess : IBaseAccess<WareHouseDetailModel>
    {
        int GetEntityCount(int companyID, string name);

        List<WareHouseDetailModel> GetPagerWareHouseDetailByConditions(int companyID, string name, int pageIndex, int pageSize);

    }
}
