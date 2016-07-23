using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IService
{
    /// <summary>
    /// 加工厂接收的加工明细信息管理
    /// </summary>
    public interface IProcessBatchDetailService
    {
        /// <summary>
        /// 获取ProcessBatchDetail总条数
        /// </summary>
        /// <returns></returns>
        int GetProcessBatchDetailCount();

        /// <summary>
        /// 获取ProcessBatchDetail总条数
        /// </summary>
        /// <param name="code">查询条件：批次编号（模糊查询）</param>
        /// <returns></returns>
        int GetProcessBatchDetailCount(string code);

        /// <summary>
        /// 获取当前用户所在公司的加工明细信息管理（分页）
        /// </summary>
        /// <param name="code">查询条件：批次编号（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        List<ProcessBatchDetailModel> GetPagerProcessBatchDetail(string code, int pageIndex, int pageSize);

        /// <summary>
        /// 通过ID获取ProcessBatchDetail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ProcessBatchDetailModel GetProcessBatchDetailById(int id);

        /// <summary>
        /// 新增单条ProcessBatchDetail
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel InsertSingleProcessBatchDetail(ProcessBatchDetailModel model);

        /// <summary>
        /// 编辑单条ProcessBatchDetail
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel UpdateSingleProcessBatchDetail(ProcessBatchDetailModel model);

        /// <summary>
        /// 删除单条ProcessBatchDetail
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        MessageModel DeleteSingleProcessBatchDetail(int id);
    }
}
