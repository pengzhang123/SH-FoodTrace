using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IDBAccess
{
    public interface IRoleAccess:IBaseAccess<RoleModel>
    {
        int GetEntityCount(string name);

        List<RoleModel> GetPagerRoleByConditions(string name, int pageIndex, int pageSize);

        MessageModel InsertSingleEntity(RoleModel roleModel, List<RoleMenuModel> roleMenuModel);

        /// <summary>
        /// 根据角色id获取角色所拥有的权限
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<int> GetMenuListByRoleId(int id);


        /// <summary>
        /// 更新权限菜单
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="list"></param>
        /// <returns></returns>
       MessageModel UpdateRoleMenu(int roleId, List<RoleMenuModel> list);

       /// <summary>
       /// 根据角色Id获取角色菜单
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       List<MenuModel> GetRoleMenuByRoleId(int id);

        /// <summary>
        /// 保存用户关联角色数据
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="roleIds"></param>
       MessageModel SaveUserRefRole(int uid, List<int> roleIds);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        MessageModel DeleteRolesByIds(string ids);
    }
}
