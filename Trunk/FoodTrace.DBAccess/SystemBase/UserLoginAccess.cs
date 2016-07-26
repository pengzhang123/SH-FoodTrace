using System.Security.Cryptography;
using FoodTrace.DBManage.IContexts;
using FoodTrace.IDBAccess;
using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTrace.Model.DtoModel;

namespace FoodTrace.DBAccess
{
    public class UserLoginAccess:BaseAccess, IUserLoginAccess
    {
        public MessageModel InsertSingleEntity(LogUserLoginModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                context.LogUserLogin.Add(model);
                context.SaveChanges();
                return string.Empty;
            };
            return base.DbOperation(operation);
        }

         /// <summary>
         /// 登录用户获取用户相关信息
         /// </summary>
         /// <param name="uid"></param>
         /// <param name="pwd"></param>
         /// <returns></returns>
        public UserSessionDto GetUserLoginDto(string uid, string pwd)
        {
            var query = (from s in base.Context.UserBase
                join com in base.Context.Company on s.CompanyID equals com.CompanyID into coml
                join role in base.Context.UserRole on s.UserID equals role.UserID into rolel
                from comleft in coml.DefaultIfEmpty()
                from roleft in rolel.DefaultIfEmpty()
                where s.UserCode == uid && s.Password == pwd
                select new UserSessionDto()
                {
                    UserID = s.UserID,
                    UserCode = s.UserCode,
                    UserName = s.UserName,
                    RoleId = roleft.RoleID ?? 0,
                    CompanyId = comleft.CompanyID,
                    CompanyName = comleft.CompanyName

                }).FirstOrDefault();

            return query;
        }
    }
}
