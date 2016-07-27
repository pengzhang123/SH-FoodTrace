using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTrace.Model.DtoModel;

namespace FoodTrace.IDBAccess
{
    public interface IProcessProductAccess : IBaseAccess<ProcessProductModel>
    {
        int GetEntityCount(int companyID, string code);
        List<ProcessProductModel> GetPagerProcessProductByConditions(int companyID, string applyNo, int pageIndex, int pageSize);
        ProcessProductModel GetProcessProductByEPCOrORCode(string Epc, string OrCode);


        /// <summary>
        /// 根据epc获取orcode获取产品基本信息数据
        /// </summary>
        /// <param name="epc"></param>
        /// <param name="orCode"></param>
        /// <returns></returns>
        ProductInfoDto GetProductByEpcOrCode(string epc, string orCode);


        /// <summary>
        /// 肉类溯源
        /// </summary>
        /// <param name="epc"></param>
        /// <param name="orCode"></param>
        /// <returns></returns>
        List<ProductTraceDto> GetProductTrace(string epc, string orCode);
    }
}
