using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IDBAccess
{
    public interface ITrunVehicleAccess : IBaseAccess<TrunVehicleModel>
    {
        int GetEntityCount(int companyID, string carNo);
        List<TrunVehicleModel> GetPagerTrunVehicleByConditions(int companyID, string carNo, int pageIndex, int pageSize);
    }
}
