using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IService
{
    public interface IRoleService
    {
        /// <summary>
        /// 获取Role总条数
        /// </summary>
        /// <returns></returns>
        int GetRoleCount();

        /// <summary>
        /// 获取Role总条数
        /// </summary>
        /// <param name="name">查询条件：角色名称（模糊查询）</param>
        /// <returns></returns>
        int GetRoleCount(string name);

        /// <summary>
        /// 获取角色信息（分页）
        /// </summary>
        /// <param name="name">查询条件：角色名称（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        List<RoleModel> GetPagerRole(string name, int pageIndex, int pageSize);

        /// <summary>
        /// 通过ID获取Role
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        RoleModel GetRoleById(int id);

        /// <summary>
        /// 新增单条Role
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel InsertSingleRole(RoleModel model);

        /// <summary>
        /// 新增单条Role
        /// </summary>
        /// <param name="role">角色信息实体</param>
        /// <param name="roleMenu">角色菜单信息实体</param>
        /// <returns></returns>
        MessageModel InsertSingleRole(RoleModel role, List<RoleMenuModel> roleMenu);

        /// <summary>
        /// 编辑单条Role
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel UpdateSingleRole(RoleModel model);

        /// <summary>
        /// 删除单条Role
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        MessageModel DeleteSingleRole(int id);


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
    }
}
