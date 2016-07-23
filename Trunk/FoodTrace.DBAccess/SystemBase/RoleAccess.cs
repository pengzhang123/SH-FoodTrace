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

        public MessageModel UpdateSingleEntity(RoleModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                var data = context.Role.FirstOrDefault(m => m.RoleID == model.RoleID && m.ModifyTime == model.ModifyTime);
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

        public List<RoleModel> GetPagerRoleByConditions(string name, int pageIndex, int pageSize)
        {
            return base.Context.Role.Where(m => (string.IsNullOrEmpty(name) || m.RoleName.Contains(name)))
                    .OrderBy(m => m.RoleID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}
