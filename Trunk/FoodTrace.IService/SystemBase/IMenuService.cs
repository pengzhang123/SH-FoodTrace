using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IService
{
    public interface IMenuService
    {
        /// <summary>
        /// 获取Menu总条数
        /// </summary>
        /// <returns></returns>
        int GetMenuCount();

        /// <summary>
        /// 获取Menu总条数
        /// </summary>
        /// <param name="name">查询条件：菜单名称（模糊查询）</param>
        /// <returns></returns>
        int GetMenuCount(string name);

        /// <summary>
        /// 获取菜单信息（分页）
        /// </summary>
        /// <param name="name">查询条件：菜单名称（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        List<MenuModel> GetPagerMenu(string name, int pageIndex, int pageSize);

        /// <summary>
        /// 通过ID获取Menu
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        MenuModel GetMenuById(int id);

        /// <summary>
        /// 新增单条Menu
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel InsertSingleMenu(MenuModel model);

        /// <summary>
        /// 编辑单条Menu
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel UpdateSingleMenu(MenuModel model);

        /// <summary>
        /// 删除单条Menu
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        MessageModel DeleteSingleMenu(int id);
    }
}
