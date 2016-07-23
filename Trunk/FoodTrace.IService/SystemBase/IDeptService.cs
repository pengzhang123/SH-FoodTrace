using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IService
{
    public interface IDeptService
    {
        /// <summary>
        /// 获取Dept总条数
        /// </summary>
        /// <returns></returns>
        int GetDeptCount();

        /// <summary>
        /// 获取Dept总条数
        /// </summary>
        /// <param name="name">查询条件：部门名称（模糊查询）</param>
        /// <returns></returns>
        int GetDeptCount(string name);

        /// <summary>
        /// 获取当前用户所在公司的部门信息（分页）
        /// </summary>
        /// <param name="name">查询条件：部门名称（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        List<DeptModel> GetPagerDept(string name, int pageIndex, int pageSize, int? companyID = null);

        /// <summary>
        /// 通过ID获取Dept
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        DeptModel GetDeptById(int id);

        /// <summary>
        /// 新增单条Dept
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel InsertSingleDept(DeptModel model);

        /// <summary>
        /// 编辑单条Dept
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel UpdateSingleDept(DeptModel model);

        /// <summary>
        /// 删除单条Dept
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        MessageModel DeleteSingleDept(int id);
    }
}
