using FoodTrace.Common.Libraries;
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
    public class RoleService : BaseService, IRoleService
    {
        private IRoleAccess roleAccess;

        public RoleService()
        {
            roleAccess = BaseAccess.CreateAccess<IRoleAccess>(AccessMappingKey.RoleAccess.ToString());
        }

        /// <summary>
        /// 获取Role总条数
        /// </summary>
        /// <returns></returns>
        public int GetRoleCount()
        {
            return roleAccess.GetEntityCount();
        }

        /// <summary>
        /// 获取Role总条数
        /// </summary>
        /// <param name="name">查询条件：角色名称（模糊查询）</param>
        /// <returns></returns>
        public int GetRoleCount(string name)
        {
            return roleAccess.GetEntityCount(name.Trim());
        }

        /// <summary>
        /// 获取角色信息（分页）
        /// </summary>
        /// <param name="name">查询条件：角色名称（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        public List<RoleModel> GetPagerRole(string name, int pageIndex, int pageSize)
        {
            return roleAccess.GetPagerRoleByConditions(name.Trim(), pageIndex, pageSize);
        }

        /// <summary>
        /// 通过ID获取Role
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public RoleModel GetRoleById(int id)
        {
            return roleAccess.GetEntityById(id);
        }

        /// <summary>
        /// 新增单条Role
        /// </summary>
        /// <param name="model">角色信息实体</param>
        /// <returns></returns>
        public MessageModel InsertSingleRole(RoleModel model)
        {
            return roleAccess.InsertSingleEntity(model);
        }

        /// <summary>
        /// 新增单条Role
        /// </summary>
        /// <param name="role">角色信息实体</param>
        /// <param name="roleMenu">角色菜单信息实体</param>
        /// <returns></returns>
        public MessageModel InsertSingleRole(RoleModel role, List<RoleMenuModel> roleMenu)
        {
            return roleAccess.InsertSingleEntity(role, roleMenu);
        }

        /// <summary>
        /// 编辑单条Role
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        public MessageModel UpdateSingleRole(RoleModel model)
        {
            return roleAccess.UpdateSingleEntity(model);
        }

        /// <summary>
        /// 删除单条Role
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public MessageModel DeleteSingleRole(int id)
        {
            return roleAccess.DeleteSingleEntity(id);
        }


    }
}
