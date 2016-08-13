using System.Security.Cryptography;
using FoodTrace.Common.Libraries;
using FoodTrace.DBManage.IContexts;
using FoodTrace.IDBAccess;
using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.DBAccess
{
    public class RoleAccess : BaseAccess, IRoleAccess
    {
        public int GetEntityCount()
        {
            return base.Context.Role.Count();
        }

        public int GetEntityCount(string name)
        {
            return base.Context.Role.Where(m => (string.IsNullOrEmpty(name) || m.RoleName.Contains(name))).Count();
        }

        public List<RoleModel> GetAllEntities()
        {
            return base.Context.Role.ToList();
        }

        public RoleModel GetEntityById(int id)
        {
            return base.Context.Role.FirstOrDefault(m => m.RoleID == id);
        }

        public MessageModel InsertSingleEntity(RoleModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                context.Role.Add(model);
                context.SaveChanges();
                return string.Empty;
            };
            return base.DbOperation(operation);
        }

        public MessageModel InsertSingleEntity(RoleModel roleModel, List<RoleMenuModel> roleMenuModel)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                context.Role.Add(roleModel);
                context.SaveChanges();
                int id = roleModel.RoleID;
                foreach (var item in roleMenuModel)
                {
                    item.RoleID = id;
                    context.RoleMenu.Add(item);
                }
                context.SaveChanges();
                return string.Empty;
            };
            return base.DbOperation(operation);
        }

        public RoleModel GetOriEntity(int id, DateTime? modifyTime)
        {
            return base.Context.Role.FirstOrDefault(m => m.RoleID == id && m.ModifyTime == modifyTime);
        }

        /// <summary>
        /// 更新单个实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageModel UpdateSingleEntity(RoleModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                var data = context.Role.FirstOrDefault(m => m.RoleID == model.RoleID);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";
                data.RoleName = model.RoleName;
                data.Remark = model.Remark;
                data.SortID = model.SortID;

                data.IsLocked = model.IsLocked;
                data.CreateID = model.CreateID;
                data.CreateName = model.CreateName;
                data.CreateTime = model.CreateTime;
                data.ModifyID = UserManagement.CurrentUser.UserID;
                data.ModifyName = UserManagement.CurrentUser.UserName;
                data.ModifyTime = DateTime.Now;
                context.SaveChanges();
                return string.Empty;
            };
            return base.DbOperation(operation);
        }

        /// <summary>
        /// 更新权限菜单
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public MessageModel UpdateRoleMenu(int roleId,List<RoleMenuModel> list,int flag)
        {
            Func<IEntityContext, string> operation = delegate(IEntityContext context)
            {
                var data = context.RoleMenu.Where(s=>s.RoleID==roleId && s.Flag==flag).ToList();
                if (data.Any())
                {

                    context.BatchDelete<RoleMenuModel>(data);
                    //context.SaveChanges();
                }

                if (list.Any())
                {
                    list.ForEach(s =>
                    {
                        s.RoleID = roleId;
                        s.Flag = flag;
                    });
                    context.BatctInsert(list);
                }
                return string.Empty;
            };

            return base.DbOperation(operation);
        }
        public MessageModel DeleteSingleEntity(int id)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                if (context.UserRole.Any(m => m.RoleID == id) || context.RoleMenu.Any(m => m.RoleID == id)) return "该角色信息存在关联数据，不能被删除！";

                var data = context.Role.FirstOrDefault(m => m.RoleID == id);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";
                context.DeleteAndSave<RoleModel>(data);
                return string.Empty;
            };

            return base.DbOperationInTransaction(operation);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public MessageModel DeleteRolesByIds(string ids)
        {
            Func<IEntityContext, string> operation = delegate(IEntityContext context)
            {
                var roles = context.Role.Where(s => ids.Contains(s.RoleID.ToString())).ToList();
                if (roles.Any())
                {
                    context.BatchDelete(roles);
                }
                return string.Empty;
            };

            return base.DbOperationInTransaction(operation);
        }

        public List<RoleModel> GetPagerRoleByConditions(string name, int pageIndex, int pageSize)
        {
            return base.Context.Role.Where(m => (string.IsNullOrEmpty(name) || m.RoleName.Contains(name)))
                    .OrderBy(m => m.RoleID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        /// <summary>
        /// 根据角色id获取角色所拥有的权限
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<int> GetMenuListByRoleId(int id,int flag)
        {
            var query = (from s in base.Context.RoleMenu.Where(s => s.RoleID == id && s.Flag==flag)
                select s.MenuID).ToList();

            return query;
        }

        /// <summary>
        /// 获取角色树
        /// </summary>
        /// <returns></returns>
        public List<ZtreeModel> GetRoleTree()
        {
            var list = new List<ZtreeModel>();
            list = (from s in Context.Role
                select new ZtreeModel()
                {
                    id = s.RoleID.ToString(),
                    name = s.RoleName
                }).ToList();
            return list;
        }
        /// <summary>
        /// 根据角色Id获取角色菜单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<MenuModel> GetRoleMenuByRoleId(int id,int flag)
        {
            var query = (from s in base.Context.RoleMenu.Where(s => s.RoleID == id && s.Flag==flag)
                        join m in Context.Menu on s.MenuID equals m.MenuID
                        orderby m.SortID
                       select m ).ToList();

            return query;
        }

        /// <summary>
        /// 保存用户关联角色数据
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="roleIds"></param>
        public MessageModel SaveUserRefRole(int uid, List<int> roleIds)
        {
            Func<IEntityContext, string> operation = delegate(IEntityContext context)
            {
                var userRefRole = context.UserRole.Where(s => s.UserID == uid).ToList();

                context.BatchDelete(userRefRole);
                if (roleIds != null)
                {
                    if (roleIds.Any())
                    {
                        var list = new List<UserRoleModel>();
                        roleIds.ForEach(s =>
                        {
                            var model = new UserRoleModel();
                            model.RoleID = s;
                            model.UserID = uid;
                            model.CreateID = UserManagement.CurrentUser.UserID;
                            model.CreateTime = DateTime.Now;
                            list.Add(model);
                           
                        });

                        context.BatctInsert(list);
                    }
                }
                return string.Empty;
            };

            return base.DbOperationInTransaction(operation);
        }
    }
}
