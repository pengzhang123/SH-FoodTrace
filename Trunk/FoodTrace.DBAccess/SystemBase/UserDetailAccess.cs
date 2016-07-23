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
    public class UserDetailAccess : BaseAccess, IUserDetailAccess
    {
        public int GetEntityCount()
        {
            return base.Context.UserDetail.Count();
        }

        //public int GetEntityCount(int companyID, string name)
        //{
        //    return base.Context.UserDetail.Where(m => m.UserBase.CompanyID == companyID
        //                                    && (string.IsNullOrEmpty(name) || m.UserBase.UserName.Contains(name))).Count();
        //}

        public List<UserDetailModel> GetAllEntities()
        {
            return base.Context.UserDetail.ToList();
        }

        public UserDetailModel GetEntityById(int id)
        {
            return base.Context.UserDetail.FirstOrDefault(m => m.UserID == id);
        }

        public MessageModel InsertSingleEntity(UserDetailModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                model.UserBase = null;
                context.UserDetail.Add(model);
                context.SaveChanges();
                return string.Empty;
            };
            return base.DbOperation(operation);
        }

        //public UserDetailModel GetOriEntity(int id, DateTime? modifyTime)
        //{
        //    return base.Context.UserDetail.FirstOrDefault(m => m.UserID == id && m.UserBase.ModifyTime == modifyTime);
        //}

        public MessageModel UpdateSingleEntity(UserDetailModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                var data = context.UserDetail.FirstOrDefault(m => m.UserID == model.UserID/* && m.UserBase.ModifyTime == model.UserBase.ModifyTime*/);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";
                data.UserPhoto = model.UserPhoto;
                data.EntryDate = model.EntryDate;
                data.FormalDate = model.FormalDate;
                data.LeaveDate = model.LeaveDate;
                data.QQ = model.QQ;
                data.BirthDay = model.BirthDay;
                data.Email = model.Email;
                data.IDCard = model.IDCard;
                data.Mobile = model.Mobile;
                data.Marriage = model.Marriage;
                data.Gender = model.Gender;
                data.Education = model.Education;
                data.HomeAddress = model.HomeAddress;
                data.Remark = model.Remark;
                data.AttendanceNo = model.AttendanceNo;
                data.BankNo = model.BankNo;
                context.SaveChanges();
                return string.Empty;
            };
            return base.DbOperation(operation);
        }

        public MessageModel DeleteSingleEntity(int id)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                var data = context.UserDetail.FirstOrDefault(m => m.UserID == id);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";
                context.DeleteAndSave<UserDetailModel>(data);
                return string.Empty;
            };

            return base.DbOperationInTransaction(operation);
        }

        //public List<UserDetailModel> GetPagerUserDetailByConditions(int companyID, string name, int pageIndex, int pageSize)
        //{
        //    return base.Context.UserDetail.Where(m => m.UserBase.CompanyID == companyID
        //                                    && (string.IsNullOrEmpty(name) || m.UserBase.UserName.Contains(name)))
        //            .OrderBy(m => m.UserID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        //}
    }
}
