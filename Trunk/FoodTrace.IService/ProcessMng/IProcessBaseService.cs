using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IService
{
    /// <summary>
    /// 生产加工工序基本信息管理
    /// </summary>
    public interface IProcessBaseService
    {
        /// <summary>
        /// 获取ProcessBase总条数
        /// </summary>
        /// <returns></returns>
        int GetProcessBaseCount();

        /// <summary>
        /// 获取ProcessBase总条数
        /// </summary>
        /// <param name="name">查询条件：工序名称（模糊查询）</param>
        /// <returns></returns>
        int GetProcessBaseCount(string name);

        /// <summary>
        /// 获取生产加工工序基本信息（分页）
        /// </summary>
        /// <param name="name">查询条件：工序名称（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        List<ProcessBaseModel> GetPagerProcessBase(string name, int pageIndex, int pageSize);

        /// <summary>
        /// 通过ID获取ProcessBase
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ProcessBaseModel GetProcessBaseById(int id);

        /// <summary>
        /// 新增单条ProcessBase
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel InsertSingleProcessBase(ProcessBaseModel model);

        /// <summary>
        /// 编辑单条ProcessBase
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel UpdateSingleProcessBase(ProcessBaseModel model);

        /// <summary>
        /// 删除单条ProcessBase
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        MessageModel DeleteSingleProcessBase(int id);
    }
}
