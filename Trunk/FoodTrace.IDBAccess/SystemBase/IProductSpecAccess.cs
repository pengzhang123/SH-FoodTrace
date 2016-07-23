using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FoodTrace.IDBAccess
{
    public interface IProductSpecAccess : IBaseAccess<ProductSpecModel>
    {
        int GetEntityCount(string name);

        List<ProductSpecModel> GetPagerProductSpecByConditions(string name, int pageIndex, int pageSize);
    }
}
