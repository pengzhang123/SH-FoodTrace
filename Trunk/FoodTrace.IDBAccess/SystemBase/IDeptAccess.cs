using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTrace.Model.BaseDto;

namespace FoodTrace.IDBAccess
{
    public interface IDeptAccess : IBaseAccess<DeptModel>
    {
        int GetEntityCount(int companyID, string name);

        List<DeptModel> GetPagerDeptByConditions(string name, int pageIndex, int pageSize,int? companyID);

        /// <summary>
        /// 部门分页数据
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pIndex"></param>
        /// <param name="pSize"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        GridList<DeptDto> GetDeptPagingList(string name, int pIndex, int pSize, int? companyId);
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        MessageModel DeleteDepts(string ids);
    }
}
