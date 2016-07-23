using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IService
{
    /// <summary>
    ///养殖计划明细管理
    /// </summary>
    public interface IBreedBatchDetailService
    {
        /// <summary>
        /// 获取BreedBatchDetail总条数
        /// </summary>
        /// <returns></returns>
        int GetBreedBatchDetailCount();

        /// <summary>
        /// 获取BreedBatchDetail总条数
        /// </summary>
        /// <returns></returns>
        int GetBreedBatchDetailCount(string name);

        /// <summary>
        /// 获取当前用户所在公司的养殖计划明细信息（分页）
        /// </summary>
        /// <param name="name">查询条件：地块名称（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        List<BreedBatchDetailModel> GetPagerBreedBatchDetail(string name, int pageIndex, int pageSize);

        /// <summary>
        /// 通过ID获取BreedBatchDetail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        BreedBatchDetailModel GetBreedBatchDetailById(int id);

        /// <summary>
        /// 新增单条BreedBatchDetail
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel InsertSingleBreedBatchDetail(BreedBatchDetailModel model);

        /// <summary>
        /// 编辑单条BreedBatchDetail
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel UpdateSingleBreedBatchDetail(BreedBatchDetailModel model);

        /// <summary>
        /// 删除单条BreedBatchDetaile
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        MessageModel DeleteSingleEntity(int id);
    }
}
