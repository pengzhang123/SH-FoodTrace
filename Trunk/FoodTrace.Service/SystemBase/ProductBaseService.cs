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
    public class ProductBaseService : BaseService, IProductBaseService
    {
        private IProductBaseAccess productBaseAccess;

        public ProductBaseService()
        {
            productBaseAccess = BaseAccess.CreateAccess<IProductBaseAccess>(AccessMappingKey.ProductBaseAccess.ToString());
        }

        /// <summary>
        /// 获取ProductBase总条数
        /// </summary>
        /// <returns></returns>
        public int GetProductBaseCount()
        {
            return productBaseAccess.GetEntityCount();
        }

        /// <summary>
        /// 获取ProductBase总条数
        /// </summary>
        /// <param name="name">查询条件：菜单名称（模糊查询）</param>
        /// <returns></returns>
        public int GetProductBaseCount(string name)
        {
            return productBaseAccess.GetEntityCount(name.Trim());
        }

        /// <summary>
        /// 获取菜单信息（分页）
        /// </summary>
        /// <param name="name">查询条件：菜单名称（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        public List<ProductBaseModel> GetPagerProductBase(string name, int pageIndex, int pageSize)
        {
            return productBaseAccess.GetPagerProductBaseByConditions(name.Trim(), pageIndex, pageSize);
        }

        /// <summary>
        /// 通过ID获取ProductBase
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProductBaseModel GetProductBaseById(int id)
        {
            return productBaseAccess.GetEntityById(id);
        }

        /// <summary>
        /// 新增单条ProductBase
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        public MessageModel InsertSingleProductBase(ProductBaseModel model)
        {
            return productBaseAccess.InsertSingleEntity(model);
        }

        /// <summary>
        /// 编辑单条ProductBase
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        public MessageModel UpdateSingleProductBase(ProductBaseModel model)
        {
            return productBaseAccess.UpdateSingleEntity(model);
        }

        /// <summary>
        /// 删除单条ProductBase
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public MessageModel DeleteSingleProductBase(int id)
        {
            return productBaseAccess.DeleteSingleEntity(id);
        }
    }
}
