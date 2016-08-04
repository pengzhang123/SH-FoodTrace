using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IDBAccess
{
    public interface IDeptAccess : IBaseAccess<DeptModel>
    {
        int GetEntityCount(int companyID, string name);

        List<DeptModel> GetPagerDeptByConditions(string name, int pageIndex, int pageSize,int? companyID);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        MessageModel DeleteDepts(string ids);
    }
}
