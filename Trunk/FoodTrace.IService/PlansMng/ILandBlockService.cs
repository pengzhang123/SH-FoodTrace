using FoodTrace.Model;
using System.Collections.Generic;

namespace FoodTrace.IService
{
    /// <summary>
    /// 地块管理
    /// </summary>
    public interface ILandBlockService
    {
        /// <summary>
        /// 获取LandBlock总条数
        /// </summary>
        /// <returns></returns>
        int GetLandBlockCount();

        /// <summary>
        /// 获取LandBlock总条数
        /// </summary>
        /// <param name="name">查询条件：地块名称（模糊查询）</param>
        /// <returns></returns>
        int GetLandBlockCount(string name);

        /// <summary>
        /// 获取当前用户所在公司的地块信息（分页）
        /// </summary>
        /// <param name="name">查询条件：地块名称（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        List<LandBlockModel> GetPagerLandBlock(string name, int pageIndex, int pageSize);

        /// <summary>
        /// 通过ID获取LandBlock
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        LandBlockModel GetLandBlockById(int id);

        /// <summary>
        /// 新增单条LandBlock
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel InsertSingleLandBlock(LandBlockModel model);

        /// <summary>
        /// 编辑单条LandBlock
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel UpdateSingleLandBlock(LandBlockModel model);

        /// <summary>
        /// 删除单条LandBlock
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        MessageModel DeleteSingleLandBlock(int id);
    }
}
