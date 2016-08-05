using FoodTrace.DBAccess;
using FoodTrace.IDBAccess;
using FoodTrace.IService;
using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.Service
{
    public class ProductSpecService : BaseService, IProductSpecService
    {
        private IProductSpecAccess productSpecAccess;

        public ProductSpecService()
        {
            productSpecAccess = BaseAccess.CreateAccess<IProductSpecAccess>(AccessMappingKey.ProductSpecAccess.ToString());
        }

        /// <summary>
        /// 获取ProductSpec总条数
        /// </summary>
        /// <returns></returns>
        public int GetProductSpecCount()
        {
            return productSpecAccess.GetEntityCount();
        }

        /// <summary>
        /// 获取ProductSpec总条数
        /// </summary>
        /// <param name="name">查询条件：菜单名称（模糊查询）</param>
        /// <returns></returns>
        public int GetProductSpecCount(string name)
        {
            return productSpecAccess.GetEntityCount(name.Trim());
        }

        /// <summary>
        /// 获取菜单信息（分页）
        /// </summary>
        /// <param name="name">查询条件：菜单名称（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        public List<ProductSpecModel> GetPagerProductSpec(string name, int pageIndex, int pageSize)
        {
            return productSpecAccess.GetPagerProductSpecByConditions(name.Trim(), pageIndex, pageSize);
        }

        /// <summary>
        /// 通过ID获取ProductSpec
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProductSpecModel GetProductSpecById(int id)
        {
            return productSpecAccess.GetEntityById(id);
        }

        /// <summary>
        /// 新增单条ProductSpec
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        public MessageModel InsertSingleProductSpec(ProductSpecModel model)
        {
            return productSpecAccess.InsertSingleEntity(model);
        }

        /// <summary>
        /// 编辑单条ProductSpec
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        public MessageModel UpdateSingleProductSpec(ProductSpecModel model)
        {
            return productSpecAccess.UpdateSingleEntity(model);
        }

        /// <summary>
        /// 删除单条ProductSpec
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public MessageModel DeleteSingleProductSpec(int id)
        {
            return productSpecAccess.DeleteSingleEntity(id);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public MessageModel DeleteByIds(string ids)
        {
            return productSpecAccess.DeleteByIds(ids);
        }
    }
}
