using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTrace.DBAccess;
using FoodTrace.IDBAccess;
using FoodTrace.IDBAccess.ProdcutTraceApi;
using FoodTrace.IService.ProductTrace;
using FoodTrace.Model;
using FoodTrace.Model.DtoModel;

namespace FoodTrace.Service.ProductTrace
{
    public class ProductTraceApiService:BaseService,IProductTraceApiService
    {
        private readonly IProductTraceApiAccess _productTraceApi;

        public ProductTraceApiService()
        {
           _productTraceApi= BaseAccess.CreateAccess<IProductTraceApiAccess>(AccessMappingKey.ProductTraceApiAccess.ToString());
        }

        /// <summary>
        /// 根据epc获取orcode获取产品基本信息数据
        /// </summary>
        /// <param name="epc"></param>
        /// <param name="orCode"></param>
        /// <returns></returns>
        public CultivationDto GetProductByEpcOrCode(string epc, string orCode)
        {
            return _productTraceApi.GetProductByEpcOrCode(epc, orCode);
        }
    }
}
