using FoodTrace.Model;
using System;
using System.Collections.Generic;

namespace FoodTrace.IService
{
    public interface IProductSpecService
    {
        /// <summary>
        /// 获取ProductSpec总条数
        /// </summary>
        /// <returns></returns>
        int GetProductSpecCount();

        /// <summary>
        /// 获取ProductSpec总条数
        /// </summary>
        /// <param name="name">查询条件：菜单名称（模糊查询）</param>
        /// <returns></returns>
        int GetProductSpecCount(string name);

        /// <summary>
        /// 获取菜单信息（分页）
        /// </summary>
        /// <param name="name">查询条件：菜单名称（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        List<ProductSpecModel> GetPagerProductSpec(string name, int pageIndex, int pageSize);

        /// <summary>
        /// 通过ID获取ProductSpec
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ProductSpecModel GetProductSpecById(int id);

        /// <summary>
        /// 新增单条ProductSpec
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel InsertSingleProductSpec(ProductSpecModel model);

        /// <summary>
        /// 编辑单条ProductSpec
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel UpdateSingleProductSpec(ProductSpecModel model);

        /// <summary>
        /// 删除单条ProductSpec
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        MessageModel DeleteSingleProductSpec(int id);
    }
}

