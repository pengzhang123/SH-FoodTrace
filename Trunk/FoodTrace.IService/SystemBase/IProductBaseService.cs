using FoodTrace.Model;
using System;
using System.Collections.Generic;

namespace FoodTrace.IService
{
    public interface IProductBaseService
    {
        /// <summary>
        /// 获取ProductBase总条数
        /// </summary>
        /// <returns></returns>
        int GetProductBaseCount();

        /// <summary>
        /// 获取ProductBase总条数
        /// </summary>
        /// <param name="name">查询条件：菜单名称（模糊查询）</param>
        /// <returns></returns>
        int GetProductBaseCount(string name);

        /// <summary>
        /// 获取菜单信息（分页）
        /// </summary>
        /// <param name="name">查询条件：菜单名称（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        List<ProductBaseModel> GetPagerProductBase(string name, int pageIndex, int pageSize);

        /// <summary>
        /// 通过ID获取ProductBase
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ProductBaseModel GetProductBaseById(int id);

        /// <summary>
        /// 新增单条ProductBase
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel InsertSingleProductBase(ProductBaseModel model);

        /// <summary>
        /// 编辑单条ProductBase
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel UpdateSingleProductBase(ProductBaseModel model);

        /// <summary>
        /// 删除单条ProductBase
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        MessageModel DeleteSingleProductBase(int id);
    }
}
