using FoodTrace.Model;
using System;
using System.Collections.Generic;

namespace FoodTrace.IService
{
    public interface IProductTypeService
    {
        /// <summary>
        /// 获取ProductType总条数
        /// </summary>
        /// <returns></returns>
        int GetProductTypeCount();

        /// <summary>
        /// 获取ProductType总条数
        /// </summary>
        /// <param name="name">查询条件：菜单名称（模糊查询）</param>
        /// <returns></returns>
        int GetProductTypeCount(string name);

        /// <summary>
        /// 获取菜单信息（分页）
        /// </summary>
        /// <param name="name">查询条件：菜单名称（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        List<ProductTypeModel> GetPagerProductType(string name, int pageIndex, int pageSize);

        /// <summary>
        /// 通过ID获取ProductType
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ProductTypeModel GetProductTypeById(int id);

        /// <summary>
        /// 新增单条ProductType
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel InsertSingleProductType(ProductTypeModel model);

        /// <summary>
        /// 编辑单条ProductType
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel UpdateSingleProductType(ProductTypeModel model);

        /// <summary>
        /// 删除单条ProductType
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        MessageModel DeleteSingleProductType(int id);
    }
}
