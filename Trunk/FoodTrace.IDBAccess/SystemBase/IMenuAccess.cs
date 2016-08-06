using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IDBAccess
{
    public interface IMenuAccess : IBaseAccess<MenuModel>
    {
        int GetEntityCount(string name);

        List<MenuModel> GetPagerMenuByConditions(string name, int pageIndex, int pageSize);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        MessageModel DeletMenuByIds(string ids);

        /// <summary>
        /// 获取菜单数据
        /// </summary>
        /// <returns></returns>
        List<ZtreeModel> GetMenuTreeList(int flag);
    }
}
