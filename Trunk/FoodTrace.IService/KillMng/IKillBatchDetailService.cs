using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTrace.Model.BaseDto;
using FoodTrace.Model.DtoModel;

namespace FoodTrace.IService
{
    /// <summary>
    /// 屠宰明细查询
    /// </summary>
    public interface IKillBatchDetailService
    {
        /// <summary>
        /// 获取KillBatchDetail总条数
        /// </summary>
        /// <returns></returns>
        int GetKillBatchDetailCount();

        /// <summary>
        /// 获取KillBatchDetail总条数
        /// </summary>
        /// <param name="code">查询条件：溯源码（模糊查询）</param>
        /// <returns></returns>
        int GetKillBatchDetailCount(string code);

        /// <summary>
        /// 获取当前用户所在公司的屠宰详细信息（分页）
        /// </summary>
        /// <param name="code">查询条件：溯源码（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        List<KillBatchDetailModel> GetPagerKillBatchDetail(string code, int pageIndex, int pageSize);

        /// <summary>
        /// 通过ID获取KillBatchDetail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        KillBatchDetailModel GetKillBatchDetailById(int id);

        /// <summary>
        /// 新增单条KillBatchDetail
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel InsertSingleKillBatchDetail(KillBatchDetailModel model);

        /// <summary>
        /// 编辑单条KillBatchDetail
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel UpdateSingleKillBatchDetail(KillBatchDetailModel model);

        /// <summary>
        /// 删除单条KillBatchDetail
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        MessageModel DeleteSingleKillBatchDetail(int id);

        /// <summary>
        /// 获取数据分页
        /// </summary>
        /// <param name="epc"></param>
        /// <param name="comId"></param>
        /// <param name="pIndex"></param>
        /// <param name="pSize"></param>
        /// <returns></returns>
        GridList<KillBatchDetailDto> GetKillBatchDetailListPaging(string epc, int pIndex, int pSize);

        /// <summary>
        /// 根据id获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        KillBatchDetailDto GetKillBatchDetalDtoById(int id);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        MessageModel DeleteByIds(string ids);
    }
}
