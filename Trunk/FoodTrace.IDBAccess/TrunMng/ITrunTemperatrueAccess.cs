using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IDBAccess
{
    public interface ITrunTemperatrueAccess : IBaseAccess<TrunTemperatrueModel>
    {
        int GetEntityCount(int companyID);
        List<TrunTemperatrueModel> GetPagerTrunTemperatrueByConditions(int companyID, int pageIndex, int pageSize);
    }
}
