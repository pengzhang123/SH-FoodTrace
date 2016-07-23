using FoodTrace.Model;
using System.Collections.Generic;

namespace FoodTrace.IService
{
    /// <summary>
    /// 仓库基本信息管理
    /// </summary>
    public interface IWareHouseBaseService
    {
        /// <summary>
        /// 获取WareHouseBase总条数
        /// </summary>
        /// <returns></returns>
        int GetWareHouseBaseCount();

        /// <summary>
        /// 获取WareHouseBase总条数
        /// </summary>
        /// <param name="name">查询条件：地块名称（模糊查询）</param>
        /// <returns></returns>
        int GetWareHouseBaseCount(string name);

        /// <summary>
        /// 获取当前用户所在公司的地块信息（分页）
        /// </summary>
        /// <param name="name">查询条件：地块名称（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        List<WareHouseBaseModel> GetPagerWareHouseBase(string name, int pageIndex, int pageSize);

        /// <summary>
        /// 通过ID获取WareHouseBase
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        WareHouseBaseModel GetWareHouseBaseById(int id);

        /// <summary>
        /// 新增单条WareHouseBase
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel InsertSingleWareHouseBase(WareHouseBaseModel model);

        /// <summary>
        /// 编辑单条WareHouseBase
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel UpdateSingleWareHouseBase(WareHouseBaseModel model);

        /// <summary>
        /// 删除单条WareHouseBase
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        MessageModel DeleteSingleEntity(int id);
    }
}
