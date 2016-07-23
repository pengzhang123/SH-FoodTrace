using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IDBAccess
{
    public interface ISaleBaseAccess : IBaseAccess<SaleBaseModel>
    {
        int GetEntityCount(int companyID, string name);

        List<SaleBaseModel> GetPagerSaleBaseByConditions(int companyID, string name, int pageIndex, int pageSize);
        SaleBaseModel GetSaleBaseByEPCOrORCode(string Epc, string OrCode);
    }
}

