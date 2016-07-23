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
    public class ProductTypeService : BaseService, IProductTypeService
    {
        private IProductTypeAccess productTypeAccess;

        public ProductTypeService()
        {
           productTypeAccess = BaseAccess.CreateAccess<IProductTypeAccess>(AccessMappingKey.ProductTypeAccess.ToString());
        }

        /// <summary>
        /// 获取ProductType总条数
        /// </summary>
        /// <returns></returns>
        public int GetProductTypeCount()
        {
            return productTypeAccess.GetEntityCount();
        }

        /// <summary>
        /// 获取ProductType总条数
        /// </summary>
        /// <param name="name">查询条件：菜单名称（模糊查询）</param>
        /// <returns></returns>
        public int GetProductTypeCount(string name)
        {
            return productTypeAccess.GetEntityCount(name.Trim());
        }

        /// <summary>
        /// 获取菜单信息（分页）
        /// </summary>
        /// <param name="name">查询条件：菜单名称（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        public List<ProductTypeModel> GetPagerProductType(string name, int pageIndex, int pageSize)
        {
            return productTypeAccess.GetPagerProductTypeByConditions(name.Trim(), pageIndex, pageSize);
        }

        /// <summary>
        /// 通过ID获取ProductType
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProductTypeModel GetProductTypeById(int id)
        {
            return productTypeAccess.GetEntityById(id);
        }

        /// <summary>
        /// 新增单条ProductType
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        public MessageModel InsertSingleProductType(ProductTypeModel model)
        {
            return productTypeAccess.InsertSingleEntity(model);
        }

        /// <summary>
        /// 编辑单条ProductType
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        public MessageModel UpdateSingleProductType(ProductTypeModel model)
        {
            return productTypeAccess.UpdateSingleEntity(model);
        }

        /// <summary>
        /// 删除单条ProductType
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public MessageModel DeleteSingleProductType(int id)
        {
            return productTypeAccess.DeleteSingleEntity(id);
        }
    }
}
