using FoodTrace.Model;
using System.Collections.Generic;

namespace FoodTrace.IService
{
    /// <summary>
    /// 仓库详细信息管理
    /// </summary>
    public interface IWareHouseDetailService
    {
        /// <summary>
        /// 获取WareHouseDetail总条数
        /// </summary>
        /// <returns></returns>
        int GetWareHouseDetailCount();

        /// <summary>
        /// 获取WareHouseDetail总条数
        /// </summary>
        /// <param name="name">查询条件：地块名称（模糊查询）</param>
        /// <returns></returns>
        int GetWareHouseDetailCount(string name);

        /// <summary>
        /// 获取当前用户所在公司的地块信息（分页）
        /// </summary>
        /// <param name="name">查询条件：地块名称（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        List<WareHouseDetailModel> GetPagerWareHouseDetail(string name, int pageIndex, int pageSize);

        /// <summary>
        /// 通过ID获取WareHouseDetail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        WareHouseDetailModel GetWareHouseDetailById(int id);

        /// <summary>
        /// 新增单条WareHouseDetail
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel InsertSingleWareHouseDetail(WareHouseDetailModel model);

        /// <summary>
        /// 编辑单条WareHouseDetail
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel UpdateSingleWareHouseDetail(WareHouseDetailModel model);

        /// <summary>
        /// 删除单条WareHouseDetail
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        MessageModel DeleteSingleEntity(int id);
    }
}
