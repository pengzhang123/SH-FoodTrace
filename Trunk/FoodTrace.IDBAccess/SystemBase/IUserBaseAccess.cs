using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTrace.Model.BaseDto;

namespace FoodTrace.IDBAccess
{
    public interface IUserBaseAccess : IBaseAccess<UserBaseModel>
    {
        int GetEntityCount(int companyID, string name);
        UserBaseModel GetUserBase(string name, string password);
        MessageModel InsertSingleEntity(UserBaseModel userBaseModel, UserDetailModel userDetailModel, List<int> roleModel);
        List<UserBaseModel> GetPagerUserBaseByConditions(int companyID, string name, int pageIndex, int pageSize);

        /// <summary>
        /// 获取当前用户所在公司的人员信息（分页）
        /// </summary>
        /// <param name="name">查询条件：人员名称（模糊查询）</param>
        /// <param name="pIndex">页码</param>
        /// <param name="pSize">每页显示条数</param>
        /// <returns></returns>
        List<UserBaseDto> GetUserBasePaging(int comId, string name, int pIndex, int pSize);

        UserBaseDto GetUserBaseById(int id);

        /// <summary>
        /// 新增用户数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        MessageModel InsertUserBase(UserBaseDto model);

        /// <summary>
        /// 更新用户数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        MessageModel UpdateUserBase(UserBaseDto model);

        /// <summary>
        /// 判断用户登录名是否存在
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        bool JudgeUserExist(string username);
        /// <summary>
        /// 根据条件查询分页
        /// </summary>
        /// <param name="comId"></param>
        /// <param name="pIndex"></param>
        /// <param name="pSize"></param>
        /// <param name="deptId"></param>
        /// <returns></returns>
        GridList<UserBaseDto> GetUserBasePaging(int comId, int pIndex, int pSize, int deptId, string uName);
    }
}
