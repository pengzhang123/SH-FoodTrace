using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IService
{
    /// <summary>
    /// 养殖批次管理
    /// </summary>
    public interface IBreedBatchService
    {
        /// <summary>
        /// 获取BreedBatch总条数
        /// </summary>
        /// <returns></returns>
        int GetBreedBatchCount();

        /// <summary>
        /// 获取BreedBatch总条数
        /// </summary>
        /// <returns></returns>
        int GetBreedBatchCount(string name);

        /// <summary>
        /// 获取当前用户所在公司的养殖批次信息（分页）
        /// </summary>
        /// <param name="name">查询条件：地块名称（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        List<BreedBatchModel> GetPagerBreedBatch(string name, int pageIndex, int pageSize);

        /// <summary>
        /// 通过ID获取BreedBatch
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        BreedBatchModel GetBreedBatchById(int id);

        /// <summary>
        /// 新增单条BreedBatch
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel InsertSingleBreedBatch(BreedBatchModel model);

        /// <summary>
        /// 编辑单条BreedBatch
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel UpdateSingleBreedBatch(BreedBatchModel model);

        /// <summary>
        /// 删除单条BreedBatch
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        MessageModel DeleteSingleEntity(int id);
    }
}
