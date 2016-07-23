using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FoodTrace.IDBAccess
{
    public interface IProductTypeAccess : IBaseAccess<ProductTypeModel>
    {
        int GetEntityCount(string name);

        List<ProductTypeModel> GetPagerProductTypeByConditions(string name, int pageIndex, int pageSize);
    }
}
