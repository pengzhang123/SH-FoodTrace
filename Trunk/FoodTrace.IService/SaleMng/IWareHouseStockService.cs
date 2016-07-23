using FoodTrace.Model;
using System.Collections.Generic;

namespace FoodTrace.IService
{
    /// <summary>
    /// 库存信息管理
    /// </summary>
    public interface IWareHouseStockService
    {
        /// <summary>
        /// 获取WareHouseStock总条数
        /// </summary>
        /// <returns></returns>
        int GetWareHouseStockCount();

        /// <summary>
        /// 获取WareHouseStock总条数
        /// </summary>
        /// <param name="name">查询条件：地块名称（模糊查询）</param>
        /// <returns></returns>
        int GetWareHouseStockCount(string name);

        /// <summary>
        /// 获取当前用户所在公司的地块信息（分页）
        /// </summary>
        /// <param name="name">查询条件：地块名称（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        List<WareHouseStockModel> GetPagerWareHouseStock(string name, int pageIndex, int pageSize);

        /// <summary>
        /// 通过ID获取WareHouseStock
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        WareHouseStockModel GetWareHouseStockById(int id);

        /// <summary>
        /// 新增单条WareHouseStock
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel InsertSingleWareHouseStock(WareHouseStockModel model);

        /// <summary>
        /// 编辑单条WareHouseStock
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel UpdateSingleWareHouseStock(WareHouseStockModel model);

        /// <summary>
        /// 删除单条WareHouseStock
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        MessageModel DeleteSingleEntity(int id);
    }
}
