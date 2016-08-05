using FoodTrace.DBAccess;
using FoodTrace.IDBAccess;
using FoodTrace.IService;
using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.Service
{
    public class MenuService : BaseService, IMenuService
    {
        private IMenuAccess menuAccess;

        public MenuService()
        {
            menuAccess = BaseAccess.CreateAccess<IMenuAccess>(AccessMappingKey.MenuAccess.ToString());
        }

        /// <summary>
        /// 获取Menu总条数
        /// </summary>
        /// <returns></returns>
        public int GetMenuCount()
        {
            return menuAccess.GetEntityCount();
        }

        /// <summary>
        /// 获取Menu总条数
        /// </summary>
        /// <param name="name">查询条件：菜单名称（模糊查询）</param>
        /// <returns></returns>
        public int GetMenuCount(string name)
        {
            return menuAccess.GetEntityCount(name.Trim());
        }

        /// <summary>
        /// 获取菜单信息（分页）
        /// </summary>
        /// <param name="name">查询条件：菜单名称（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        public List<MenuModel> GetPagerMenu(string name, int pageIndex, int pageSize)
        {
            return menuAccess.GetPagerMenuByConditions(name.Trim(), pageIndex, pageSize);
        }

        /// <summary>
        /// 通过ID获取Menu
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MenuModel GetMenuById(int id)
        {
            return menuAccess.GetEntityById(id);
        }

        /// <summary>
        /// 新增单条Menu
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        public MessageModel InsertSingleMenu(MenuModel model)
        {
            return menuAccess.InsertSingleEntity(model);
        }

        /// <summary>
        /// 编辑单条Menu
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        public MessageModel UpdateSingleMenu(MenuModel model)
        {
            return menuAccess.UpdateSingleEntity(model);
        }

        /// <summary>
        /// 删除单条Menu
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public MessageModel DeleteSingleMenu(int id)
        {
            return menuAccess.DeleteSingleEntity(id);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public MessageModel DeletMenuByIds(string ids)
        {
            return menuAccess.DeletMenuByIds(ids);
        }

        /// <summary>
        /// 获取菜单数据
        /// </summary>
        /// <returns></returns>
        public List<ZtreeModel> GetMenuTreeList()
        {
            return menuAccess.GetMenuTreeList();
        }
    }
}
