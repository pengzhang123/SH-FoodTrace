using System.Data.Entity;
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
           // return base.Context.UserBase.Include(s=>s.UserDetail).FirstOrDefault(s=>s.UserID==id);
            return base.Context.UserBase.Find(id);
        }

        public UserBaseDto GetUserBaseById(int id)
        {
            var userBase = new UserBaseDto();
            var model = GetEntityById(id);
            userBase.UserId = model.UserID;
            userBase.UserName = model.UserName;
            userBase.UserCode = model.UserCode;
            userBase.Password = model.Password;
            userBase.DeptID = model.DeptID??0;
            userBase.CompanyID = model.CompanyID??0;
            userBase.AreaCode = model.AreaCode;
            userBase.Status = model.Status;
            userBase.UserType = model.UserType??0;
            userBase.IsLocked = model.IsLocked;
            var userDetail = base.Context.UserDetail.FirstOrDefault(s => s.UserID == id);
            if (userDetail != null)
            {
                userBase.DetailId = userDetail.DetailID;
                userBase.UserPhoto = userDetail.UserPhoto;
                userBase.EntryDate = userDetail.EntryDate;
                userBase.FormalDate = userDetail.FormalDate;
                userBase.LeaveDate = userDetail.LeaveDate;
                userBase.QQ = userDetail.QQ;
                userBase.BirthDay = userDetail.BirthDay;
                userBase.Email = userDetail.Email;
                userBase.IDCard = userDetail.IDCard;
                userBase.Mobile = userDetail.Mobile;
                userBase.Marriage = userDetail.Marriage;
                userBase.Gender = userDetail.Gender;
                userBase.Education = userDetail.Education;
                userBase.HomeAddress = userDetail.HomeAddress;
                userBase.Remark = userDetail.Remark;
                userBase.AttendanceNo = userDetail.AttendanceNo;
                userBase.BankNo = userDetail.BankNo;
            }
            return userBase;
        }
        public MessageModel InsertSingleEntity(UserBaseModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                //if (model.UserDetail == null) model.UserDetail = new UserDetailModel() ;
                context.UserBase.Add(model);
                context.SaveChanges();
                return string.Empty;
            };
            return base.DbOperation(operation);
        }

        /// <summary>
        /// 新增用户数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageModel InsertUserBase(UserBaseDto model)
        {
            var userBase = new UserBaseModel()
            {
                UserName= model.UserName,
                UserCode = model.UserCode,
                Password = model.Password,
                DeptID = model.DeptID,
                CompanyID = model.CompanyID,
                AreaCode = model.AreaCode,
                Status = model.Status,
                UserType = model.UserType,
                IsLocked = model.IsLocked,
                CreateID = UserManagement.CurrentUser.UserID,
                CreateName = UserManagement.CurrentUser.UserName,
                CreateTime = DateTime.Now
            };

            var userDetail = new UserDetailModel()
            {
                UserPhoto = model.UserPhoto,
                EntryDate = model.EntryDate,
                FormalDate = model.FormalDate,
                LeaveDate = model.LeaveDate,
                QQ = model.QQ,
                BirthDay = model.BirthDay,
                Email = model.Email,
                IDCard = model.IDCard,
                Mobile = model.Mobile,
                Marriage = model.Marriage,
                Gender = model.Gender,
                Education = model.Education,
                HomeAddress = model.HomeAddress,
                Remark = model.Remark,
                AttendanceNo = model.AttendanceNo,
                BankNo = model.BankNo
            };
            Func<IEntityContext, string> operation = delegate(IEntityContext context)
            {
                context.UserBase.Add(userBase);
                 context.SaveChanges();
                int uid = userBase.UserID;
                userDetail.UserID = uid;
                context.UserDetail.Add(userDetail);
                context.SaveChanges();
                return string.Empty;
            };
            return base.DbOperation(operation);
        }

        /// <summary>
        /// 更新用户数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageModel UpdateUserBase(UserBaseDto model)
        {

            Func<IEntityContext, string> operation = delegate(IEntityContext context)
            {
                var data = context.UserBase.FirstOrDefault(m => m.UserID == model.UserId);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";
                data.UserCode = model.UserCode;
                //data.Password = model.Password;
                data.UserName = model.UserName;
                data.DeptID = model.DeptID;
                data.CompanyID = model.CompanyID;
                data.AreaCode = model.AreaCode;
                data.Status = model.Status;
                data.UserType = model.UserType;
                data.IsLocked = model.IsLocked;
                data.ModifyID = UserManagement.CurrentUser.UserID;
                data.ModifyName = UserManagement.CurrentUser.UserName;
                data.ModifyTime = DateTime.Now;

                //详细数据
                var userDetail = context.UserDetail.FirstOrDefault(s => s.UserID == model.UserId);

                if (userDetail == null)
                {
                    userDetail = new UserDetailModel();
                }
                userDetail.UserPhoto = model.UserPhoto;
                userDetail.EntryDate = model.EntryDate;
                userDetail.FormalDate = model.FormalDate;
                userDetail.LeaveDate = model.LeaveDate;
                userDetail.QQ = model.QQ;
                userDetail.BirthDay = model.BirthDay;
                userDetail.Email = model.Email;
                userDetail.IDCard = model.IDCard;
                userDetail.Mobile = model.Mobile;
                userDetail.Marriage = model.Marriage;
                userDetail.Gender = model.Gender;
                userDetail.Education = model.Education;
                userDetail.HomeAddress = model.HomeAddress;
                userDetail.Remark = model.Remark;
                userDetail.AttendanceNo = model.AttendanceNo;
                userDetail.BankNo = model.BankNo;

                if (userDetail.DetailID == 0)
                {
                    userDetail.UserID = model.UserId;
                    context.UserDetail.Add(userDetail);
                }
                //data.UserDetail = userDetail;
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
                data.ModifyID = UserManagement.CurrentUser.UserID;
                data.ModifyName = UserManagement.CurrentUser.UserName;
                data.ModifyTime = DateTime.Now;

                //data.UserDetail = userDetail;
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
                context.SaveChanges();
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

        /// <summary>
        /// 判断用户登录名是否存在
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool JudgeUserExist(string username)
        {
            var user = Context.UserBase.FirstOrDefault(s => s.UserCode == username);

            if (user == null)
            {
                return false;
            }

             return true;
        }
        /// <summary>
        ///根据条件查询分页
        /// </summary>
        /// <param name="comId"></param>
        /// <param name="pIndex"></param>
        /// <param name="pSize"></param>
        /// <param name="deptId"></param>
        /// <returns></returns>
        public GridList<UserBaseDto> GetUserBasePaging(int comId, int pIndex, int pSize, int deptId, string uName)
        {
            var query = (from s in Context.UserBase
                join com in Context.Company on s.CompanyID equals com.CompanyID
                join dept in Context.Dept on s.DeptID equals dept.DeptID into depl
                from deptleft in depl.DefaultIfEmpty()
                select new UserBaseDto()
                {
                    UserId = s.UserID,
                    UserCode = s.UserCode,
                    Password = s.Password,
                    UserName = s.UserName,
                    AreaCode = s.AreaCode,
                    UserType = s.UserType,
                    DeptID = s.DeptID,
                    CompanyID = s.CompanyID,
                    CompanyName = com.CompanyName,
                    DeptName = deptleft.DeptName,
                    Status = s.Status
                }).AsQueryable();

            if (comId > 0)
            {
                query = query.Where(s => s.CompanyID == comId);
            }
            if (deptId > 0)
            {
                query = query.Where(s => s.DeptID == deptId);
            }
            if (!string.IsNullOrEmpty(uName))
            {
                query = query.Where(s => s.UserName.Contains(uName));
            }
            int count = query.Count();
            var data =query.OrderBy(o=>o.UserId).Skip((pIndex - 1)*pSize).Take(pSize).ToList();

            return new GridList<UserBaseDto>(){total = count,rows =data};
        }

        /// <summary>
        /// 获取当前用户所在公司的人员信息（分页）
        /// </summary>
        /// <param name="name">查询条件：人员名称（模糊查询）</param>
        /// <param name="pIndex">页码</param>
        /// <param name="pSize">每页显示条数</param>
        /// <returns></returns>
        public List<UserBaseDto> GetUserBasePaging(int comId, string name, int pIndex, int pSize)
        {
            var query = from u in base.Context.UserBase
                join com in base.Context.Company on u.CompanyID equals com.CompanyID into coml
                join dept in base.Context.Dept on u.DeptID equals dept.DeptID into deptl
                from comleft in coml.DefaultIfEmpty()
                from deptleft in deptl.DefaultIfEmpty()
                select new UserBaseDto()
                {
                    UserId = u.UserID,
                    UserCode = u.UserCode,
                    UserName = u.UserCode,
                    Password = u.Password,
                    UserType = (int) u.UserType,
                    AreaCode = u.AreaCode,
                    CompanyName = comleft.CompanyName,
                    DeptName = deptleft.DeptName
                };
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(s => s.UserName.Contains(name));
            }

            return query.ToList();
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

             /// <summary>
            /// 批量删除
            /// </summary>
            /// <param name="ids"></param>
            /// <returns></returns>
            public MessageModel DeleteUser(string ids)
        {
            Func<IEntityContext, string> operation = delegate(IEntityContext context)
            {

                var user = context.UserBase.Where(s => ids.Contains(s.UserID.ToString())).ToList();
                if (user.Any())
                {
                    var userDetails = new List<UserDetailModel>();
                    user.ForEach(s =>
                    {
                        var udetail = context.UserDetail.FirstOrDefault(m => m.UserID == s.UserID);
                        if (udetail != null)
                        {
                            userDetails.Add(udetail);
                        }
                    });
                    context.BatchDelete(user);
                    context.BatchDelete(userDetails);
                }
                return string.Empty;
            };
            return base.DbOperation(operation);
        }

        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="newpwd"></param>
        /// <returns></returns>
        public MessageModel ResetUserPwd(string ids, string newpwd)
        {
            Func<IEntityContext, string> operation = delegate(IEntityContext context)
            {

                var user = context.UserBase.Where(s => ids.Contains(s.UserID.ToString())).ToList();
                if (user.Any())
                {
                    user.ForEach(s =>
                    {
                        s.Password = newpwd;
                    });
                    context.BatctUpdate(user);
                }
                return string.Empty;
            };
            return base.DbOperation(operation);
        }
    }
}
