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
    public interface IKillBatchService
    {
        /// <summary>
        /// 获取KillBatch总条数
        /// </summary>
        /// <returns></returns>
        int GetKillBatchCount();

        /// <summary>
        /// 获取KillBatch总条数
        /// </summary>
        /// <param name="code">查询条件：批次编号（模糊查询）</param>
        /// <returns></returns>
        int GetKillBatchCount(string code);

        /// <summary>
        /// 获取当前用户的所在公司管理的屠宰批次信息（分页）
        /// </summary>
        /// <param name="code">查询条件：批次编号（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        List<KillBatchModel> GetPagerKillBatch(string code, int pageIndex, int pageSize);

        /// <summary>
        /// 通过ID获取KillBatch
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        KillBatchModel GetKillBatchById(int id);

        /// <summary>
        /// 新增单条KillBatch
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel InsertSingleKillBatch(KillBatchModel model);

        /// <summary>
        /// 编辑单条KillBatch
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel UpdateSingleKillBatch(KillBatchModel model);

        /// <summary>
        /// 删除单条KillBatch
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        MessageModel DeleteSingleKillBatch(int id);

        /// <summary>
        /// 获取单条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        KillBatchDto GetKillBatchDtoById(int id);
        /// <summary>
        /// 屠宰批次列表
        /// </summary>
        /// <param name="comId"></param>
        /// <param name="pIndex"></param>
        /// <param name="pSize"></param>
        /// <returns></returns>
        GridList<KillBatchDto> GetKillBatchListPaging(int pIndex, int pSize);
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        MessageModel DeleteByIds(string ids);
    }
}
