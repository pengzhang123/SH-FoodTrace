using FoodTrace.Model;
using System.Collections.Generic;

namespace FoodTrace.IService
{
    /// <summary>
    /// 销售信息管理
    /// </summary>
    public interface ISaleBaseService
    {
        /// <summary>
        /// 获取SaleBase总条数
        /// </summary>
        /// <returns></returns>
        int GetSaleBaseCount();

        /// <summary>
        /// 获取SaleBase总条数
        /// </summary>
        /// <param name="name">查询条件：地块名称（模糊查询）</param>
        /// <returns></returns>
        int GetSaleBaseCount(string name);

        /// <summary>
        /// 获取当前用户所在公司的地块信息（分页）
        /// </summary>
        /// <param name="name">查询条件：地块名称（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        List<SaleBaseModel> GetPagerSaleBase(string name, int pageIndex, int pageSize);

        /// <summary>
        /// 通过ID获取SaleBase
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        SaleBaseModel GetSaleBaseById(int id);

        /// <summary>
        /// 新增单条SaleBase
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel InsertSingleSaleBase(SaleBaseModel model);

        /// <summary>
        /// 编辑单条SaleBase
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel UpdateSingleSaleBase(SaleBaseModel model);

        /// <summary>
        /// 删除单条SaleBase
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        MessageModel DeleteSingleEntity(int id);
        SaleBaseModel GetSaleBaseByEPCOrORCode(string Epc, string OrCode);
    }
}
