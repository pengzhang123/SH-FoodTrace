using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IDBAccess
{
    /// <summary>
    /// 仓库库存管理
    /// </summary>
    public interface IWareHouseStockAccess : IBaseAccess<WareHouseStockModel>
    {
        int GetEntityCount(int companyID, string name);

        List<WareHouseStockModel> GetPagerWareHouseStockByConditions(int companyID, string name, int pageIndex, int pageSize);

    }
}
