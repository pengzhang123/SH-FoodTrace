using FoodTrace.Common.Libraries;
using FoodTrace.DBManage.IContexts;
using FoodTrace.IDBAccess;
using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTrace.Model.BaseDto;

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
                model.ModifyID = UserManagement.CurrentUser.UserID;
                model.ModifyName = UserManagement.CurrentUser.UserName;
                model.ModifyTime = DateTime.Now;
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
                var data = context.Menu.FirstOrDefault(m => m.MenuID == model.MenuID);
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

        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="name"></param>
        /// <param name="pindex"></param>
        /// <param name="pSize"></param>
        /// <returns></returns>
        public GridList<MenuModel> GetMenuListPaging(int moduleId, string name, int pindex, int pSize)
        {
            var query = Context.Menu.AsQueryable();

            if (moduleId > 0)
            {
                query = query.Where(s => s.MenuID == moduleId || s.ParentID == moduleId);
            }
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(s => s.Name.Contains(name));
            }

            var list = query.OrderBy(s => s.MenuID).Skip((pindex - 1)*pSize).Take(pSize).ToList();

            return new GridList<MenuModel>(){rows =list,total = query.Count()};
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public MessageModel DeletMenuByIds(string ids)
        {
            Func<IEntityContext, string> operation = delegate(IEntityContext context)
            {
                var idsArray = ids.Split(',');
                var menu = context.Menu.Where(s => idsArray.Contains(s.MenuID.ToString())).ToList();
                if (menu.Any())
                {
                    context.BatchDelete(menu);
                }
                return string.Empty;
            };

            return base.DbOperationInTransaction(operation);
        }

        /// <summary>
        /// 获取菜单数据
        /// </summary>
        /// <returns></returns>
        public List<ZtreeModel> GetMenuTreeList(int flag)
        {
            var query = (from s in Context.Menu
                select new ZtreeModel()
                {
                    id = s.MenuID.ToString(),
                    name = s.Name,
                    pId = s.ParentID.ToString(),
                    type=s.Flag
                }).AsQueryable();

            if (flag >0)
            {
                query = query.Where(s => s.type == flag);
            }
            return query.ToList();
        }
    }
}
