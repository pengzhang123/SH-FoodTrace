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
    public class MenuAccess : BaseAccess, IMenuAccess
    {
        public int GetEntityCount()
        {
            return base.Context.Menu.Count();
        }

        public int GetEntityCount(string name)
        {
            return base.Context.Menu.Where(m => (string.IsNullOrEmpty(name) || m.Name.Contains(name))).Count();
        }

        public List<MenuModel> GetAllEntities()
        {
            return base.Context.Menu.ToList();
        }

        public MenuModel GetEntityById(int id)
        {
            return base.Context.Menu.FirstOrDefault(m => m.MenuID == id);
        }

        public MessageModel InsertSingleEntity(MenuModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                context.Menu.Add(model);
                context.SaveChanges();
                return string.Empty;
            };
            return base.DbOperation(operation);
        }

        public MenuModel GetOriEntity(int id, DateTime? modifyTime)
        {
            return base.Context.Menu.FirstOrDefault(m => m.MenuID == id && m.ModifyTime == modifyTime);
        }

        public MessageModel UpdateSingleEntity(MenuModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                var data = context.Menu.FirstOrDefault(m => m.MenuID == model.MenuID && m.ModifyTime == model.ModifyTime);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";
                data.ParentID = model.ParentID;
                data.Name = model.Name;
                data.SortID = model.SortID;
                data.IcoURL = model.IcoURL;
                data.FunctionURL = model.FunctionURL;
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
                if (context.RoleMenu.Any(m => m.MenuID == id)) return "该菜单信息存在关联数据，不能被删除！";

                var data = context.Menu.FirstOrDefault(m => m.MenuID == id);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";
                context.DeleteAndSave<MenuModel>(data);
                return string.Empty;
            };

            return base.DbOperationInTransaction(operation);
        }

        public List<MenuModel> GetPagerMenuByConditions(string name, int pageIndex, int pageSize)
        {
            return base.Context.Menu.Where(m => (string.IsNullOrEmpty(name) || m.Name.Contains(name)))
                    .OrderBy(m => m.MenuID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}
