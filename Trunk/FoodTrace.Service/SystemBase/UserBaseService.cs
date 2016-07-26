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
    public class UserBaseService : BaseService, IUserBaseService
    {
        private IUserBaseAccess userBaseAccess;
        private ICompanyAccess companyAccess;
        private IDeptAccess deptAccess;
        private IUserRoleAccess userRoleAccess;
        public UserBaseService()
        {
            userBaseAccess = BaseAccess.CreateAccess<IUserBaseAccess>(AccessMappingKey.UserBaseAccess.ToString());
            companyAccess = BaseAccess.CreateAccess<ICompanyAccess>(AccessMappingKey.CompanyAccess.ToString());
            deptAccess = BaseAccess.CreateAccess<IDeptAccess>(AccessMappingKey.DeptAccess.ToString());
            userRoleAccess = BaseAccess.CreateAccess<IUserRoleAccess>(AccessMappingKey.UserRoleAccess.ToString());

        }

        /// <summary>
        /// 获取UserBase总条数
        /// </summary>
        /// <returns></returns>
        public int GetUserBaseCount()
        {
            return userBaseAccess.GetEntityCount();
        }

        /// <summary>
        /// 获取UserBase总条数
        /// </summary>
        /// <param name="name">查询条件：部门名称（模糊查询）</param>
        /// <returns></returns>
        public int GetUserBaseCount(string name)
        {
            int companyID = UserManagement.CurrentCompany.CompanyID;
            return userBaseAccess.GetEntityCount(companyID, name.Trim());
        }

        /// <summary>
        /// 获取当前用户所在公司的人员信息（分页）
        /// </summary>
        /// <param name="name">查询条件：人员名称（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        public List<UserBaseModel> GetPagerUserBase(string name, int pageIndex, int pageSize)
        {
            int companyID = UserManagement.CurrentCompany.CompanyID;
            var result = userBaseAccess.GetPagerUserBaseByConditions(companyID, name.Trim(), pageIndex, pageSize);
            //foreach (var item in result)
            //{
            //    SetCompany(item);
            //    SetDept(item);
            //    SetUserDetail(item);
            //}
            return result;
        }

        public List<UserBaseDto> GetUserBasePaging(string name, int pIndex, int pSize)
        {
            int comId = UserManagement.CurrentCompany.CompanyID;

            return userBaseAccess.GetUserBasePaging(comId,name, pIndex, pSize);
        }
        /// <summary>
        /// 通过ID获取UserBase
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserBaseModel GetUserBaseById(int id)
        {
            return userBaseAccess.GetEntityById(id);
        }

        /// <summary>
        /// 根据ID获取userbase 包含userdetail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserBaseDto GetUserBaseWithDetailById(int id)
        {
            return userBaseAccess.GetUserBaseById(id);
        }
        /// <summary>
        /// 新增单条UserBase
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        public MessageModel InsertSingleUserBase(UserBaseModel model)
        {
            return userBaseAccess.InsertSingleEntity(model);
        }

        /// <summary>
        /// 编辑单条UserBase
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        public MessageModel UpdateSingleUserBase(UserBaseModel model)
        {
            return userBaseAccess.UpdateSingleEntity(model);
        }

        /// <summary>
        /// 删除单条UserBase
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public MessageModel DeleteSingleUserBase(int id)
        {
            return userBaseAccess.DeleteSingleEntity(id);
        }

        public UserBaseModel GetUserBase(string name, string password)
        {
            return userBaseAccess.GetUserBase(name, password);
        }

        public MessageModel InsertSingleEntity(UserBaseModel userBaseModel, UserDetailModel userDetailModel, List<int> roleModel)
        {
            return userBaseAccess.InsertSingleEntity(userBaseModel, userDetailModel, roleModel);
        }

        public MessageModel UpdateUserBase(UserBaseModel userbase, List<int> role)
        {
            return userBaseAccess.UpdateSingleEntity(userbase);
        }
        //private void SetCompany(UserBaseModel UserBase)
        //{
        //    if (UserBase.CompanyID.HasValue)
        //        UserBase.Company = companyAccess.GetEntityById(UserBase.CompanyID.Value);
        //}

        //private void SetDept(UserBaseModel UserBase)
        //{
        //    if (UserBase.DeptID.HasValue)
        //        UserBase.Dept = deptAccess.GetEntityById(UserBase.DeptID.Value);
        //}

        //private void SetUserDetail(UserBaseModel UserBase)
        //{
        //    //if (UserBase.DeptID.HasValue)
        //    //    UserBase.Dept = deptAccess.GetEntityById(UserBase.DeptID.Value);
        //}

        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageModel InsertUserBase(UserBaseDto model)
        {
            return userBaseAccess.InsertUserBase(model);
        }


        /// <summary>
        /// 更新用户数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageModel UpdateUserBase(UserBaseDto model)
        {
            return userBaseAccess.UpdateUserBase(model);
        }
    }
}
