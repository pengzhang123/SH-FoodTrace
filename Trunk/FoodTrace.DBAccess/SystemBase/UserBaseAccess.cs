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
    public class UserBaseAccess : BaseAccess, IUserBaseAccess
    {
        public int GetEntityCount()
        {
            return base.Context.UserBase.Count();
        }

        public int GetEntityCount(int companyID, string name)
        {
            return base.Context.UserBase.Where(m => m.CompanyID == companyID
                                            && (string.IsNullOrEmpty(name) || m.UserName.Contains(name))).Count();
        }

        public UserBaseModel GetUserBase(string name,string password)
        {
            return base.Context.UserBase.SingleOrDefault(_ => _.UserCode == name && _.Password == password);
        }

        public List<UserBaseModel> GetAllEntities()
        {
            return base.Context.UserBase.ToList();
        }

        public UserBaseModel GetEntityById(int id)
        {
            return base.Context.UserBase.FirstOrDefault(m => m.UserID == id);
        }

        public MessageModel InsertSingleEntity(UserBaseModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                //if (model.UserDetail == null) model.UserDetail = new UserDetailModel() ;
                context.UserBase.Add(model);
                context.SaveChanges();
                int id = model.UserID;
                model.UserID = id;
                //context.UserDetail.Add(model.);
                context.SaveChanges();
                return string.Empty;
            };
            return base.DbOperation(operation);
        }

        public UserBaseModel GetOriEntity(int id, DateTime? modifyTime)
        {
            return base.Context.UserBase.FirstOrDefault(m => m.UserID == id && m.ModifyTime == modifyTime);
        }

        public MessageModel UpdateSingleEntity(UserBaseModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                var data = context.UserBase.FirstOrDefault(m => m.UserID == model.UserID && m.ModifyTime == model.ModifyTime);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";
                data.UserCode = model.UserCode;
                data.Password = model.Password;
                data.UserName = model.UserName;
                data.DeptID = model.DeptID;
                data.CompanyID = model.CompanyID;
                data.AreaCode = model.AreaCode;
                data.Status = model.Status;
                data.UserType = model.UserType;
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
                if (context.UserRole.Any(m => m.UserID == id)) return "该用户信息存在关联数据，不能被删除！";

                var data = context.UserBase.FirstOrDefault(m => m.UserID == id);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";
                context.Delete(data);
                UserDetailModel detail = context.UserDetail.FirstOrDefault(m => m.UserID == id);
                LogUserLoginModel login = context.LogUserLogin.FirstOrDefault(m => m.UserID == id);
                if (detail != null) context.Delete(detail);
                if (login != null) context.Delete(login);
                return string.Empty;
            };

            return base.DbOperationInTransaction(operation);
        }

        public List<UserBaseModel> GetPagerUserBaseByConditions(int companyID, string name, int pageIndex, int pageSize)
        {
            return base.Context.UserBase.Where(m => m.CompanyID == companyID
                                            && (string.IsNullOrEmpty(name) || m.UserName.Contains(name)))
                    .OrderBy(m => m.UserID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        public MessageModel InsertSingleEntity(UserBaseModel userBaseModel, UserDetailModel userDetailModel, List<int> roleModel)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                context.UserBase.Add(userBaseModel);
                context.SaveChanges();
                int id = userBaseModel.UserID;
                userDetailModel.UserID = id;
                context.UserDetail.Add(userDetailModel);
                foreach (var item in roleModel)
                {
                    context.UserRole.Add(new UserRoleModel { UserID=id, RoleID = item });
                }
                context.SaveChanges();
                return string.Empty;
            };
            return base.DbOperation(operation);
        }
    }
}
