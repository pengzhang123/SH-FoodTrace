using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTrace.Model.BaseDto;

namespace FoodTrace.IService
{
    public interface IUserBaseService
    {
        /// <summary>
        /// 获取UserBase总条数
        /// </summary>
        /// <returns></returns>
        int GetUserBaseCount();

        /// <summary>
        /// 获取UserBase总条数
        /// </summary>
        /// <param name="name">查询条件：部门名称（模糊查询）</param>
        /// <returns></returns>
        int GetUserBaseCount(string name);

        /// <summary>
        /// 根据用户名和密码查询用户信息
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        UserBaseModel GetUserBase(string name, string password);

        /// <summary>
        /// 获取当前用户所在公司的人员信息（分页）
        /// </summary>
        /// <param name="name">查询条件：人员名称（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        List<UserBaseModel> GetPagerUserBase(string name, int pageIndex, int pageSize);
        /// <summary>
        /// 获取当前用户所在公司的人员信息（分页）
        /// </summary>
        /// <param name="name">查询条件：人员名称（模糊查询）</param>
        /// <param name="pIndex">页码</param>
        /// <param name="pSize">每页显示条数</param>
        /// <returns></returns>
        List<UserBaseDto> GetUserBasePaging(string name, int pIndex, int pSize);

        /// <summary>
        /// 根据条件查询分页
        /// </summary>
        /// <param name="comId"></param>
        /// <param name="pIndex"></param>
        /// <param name="pSize"></param>
        /// <param name="deptId"></param>
        /// <returns></returns>
        GridList<UserBaseDto> GetUserBasePaging(int pIndex, int pSize, int deptId, string uName);
        /// <summary>
        /// 通过ID获取UserBase
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        UserBaseModel GetUserBaseById(int id);

        /// <summary>
        /// 根据ID获取userbase 包含userdetail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        UserBaseDto GetUserBaseWithDetailById(int id);
        /// <summary>
        /// 新增单条UserBase
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel InsertSingleUserBase(UserBaseModel model);

        /// <summary>
        /// 编辑单条UserBase
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel UpdateSingleUserBase(UserBaseModel model);

        /// <summary>
        /// 删除单条UserBase
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        MessageModel DeleteSingleUserBase(int id);

        MessageModel InsertSingleEntity(UserBaseModel userBaseModel, UserDetailModel userDetailModel, List<int> roleModel);


        /// <summary>
        /// 新增用户
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
    }
}
