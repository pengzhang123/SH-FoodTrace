using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IService
{
    public interface ITrunApplyDetailService
    {
        /// <summary>
        /// 获取TrunApplyDetail总条数
        /// </summary>
        /// <returns></returns>
        int GetTrunApplyDetailCount();

        /// <summary>
        /// 获取TrunApplyDetail总条数
        /// </summary>
        /// <param name="applyNo">查询条件：物流订单号（模糊查询）</param>
        /// <returns></returns>
        int GetTrunApplyDetailCount(string applyNo);

        /// <summary>
        /// 获取当前用户所在公司的冷链物流运输订单明细信息（分页）
        /// </summary>
        /// <param name="applyNo">查询条件：物流订单号（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        List<TrunApplyDetailModel> GetPagerTrunApplyDetail(string applyNo, int pageIndex, int pageSize);

        /// <summary>
        /// 通过ID获取TrunApplyDetail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TrunApplyDetailModel GetTrunApplyDetailById(int id);

        /// <summary>
        /// 新增单条TrunApplyDetail
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel InsertSingleTrunApplyDetail(TrunApplyDetailModel model);

        /// <summary>
        /// 编辑单条TrunApplyDetail
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel UpdateSingleTrunApplyDetail(TrunApplyDetailModel model);

        /// <summary>
        /// 删除单条TrunApplyDetail
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        MessageModel DeleteSingleTrunApplyDetail(int id);
        TrunApplyDetailModel GetTrunApplyDetailByEPCOrORCode(string Epc, string OrCode);
    }
}
