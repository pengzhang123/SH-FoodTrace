using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IService
{
    public interface ITrunApplyService
    {
        /// <summary>
        /// 获取TrunApply总条数
        /// </summary>
        /// <returns></returns>
        int GetTrunApplyCount();

        /// <summary>
        /// 获取TrunApply总条数
        /// </summary>
        /// <param name="applyNo">查询条件：物流订单号（模糊查询）</param>
        /// <returns></returns>
        int GetTrunApplyCount(string applyNo);

        /// <summary>
        /// 获取当前用户所在公司的冷链物流运输订单信息（分页）
        /// </summary>
        /// <param name="applyNo">查询条件：物流订单号（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        List<TrunApplyModel> GetPagerTrunApply(string applyNo, int pageIndex, int pageSize);

        /// <summary>
        /// 通过ID获取TrunApply
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TrunApplyModel GetTrunApplyById(int id);

        /// <summary>
        /// 新增单条TrunApply
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel InsertSingleTrunApply(TrunApplyModel model);

        /// <summary>
        /// 编辑单条TrunApply
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel UpdateSingleTrunApply(TrunApplyModel model);

        /// <summary>
        /// 删除单条TrunApply
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        MessageModel DeleteSingleTrunApply(int id);
    }
}
