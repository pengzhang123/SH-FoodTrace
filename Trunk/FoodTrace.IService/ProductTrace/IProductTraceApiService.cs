using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTrace.Model.DtoModel;

namespace FoodTrace.IService.ProductTrace
{
    public interface IProductTraceApiService
    {
        /// <summary>
        /// 根据epc获取orcode获取产品基本信息数据
        /// </summary>
        /// <param name="epc"></param>
        /// <param name="orCode"></param>
        /// <returns></returns>
        CultivationDto GetProductByEpcOrCode(string epc, string orCode);
    }
}
