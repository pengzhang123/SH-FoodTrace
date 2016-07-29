using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTrace.Model.DtoModel;

namespace FoodTrace.IDBAccess
{
    public interface IShadowBaseAccess : IBaseAccess<ShadowBaseModel>
    {
        int GetEntityCount(int companyID, string code);
        List<ShadowBaseModel> GetPagerShadowBaseByConditions(int companyID, string code, int pageIndex, int pageSize);
        ShadowBaseModel GetShawInfoByEPCOrORCode(string Epc, string OrCode);
        ShadowBaseModel GetShawInfoByChipCode(string chipCode);

        /// <summary>
        /// 皮影的基本信息
        /// </summary>
        /// <param name="epc"></param>
        /// <param name="orCode"></param>
        /// <returns></returns>
        ShadowBaseDto GetShadowByEpcOrCode(string epc, string orCode);
    }
}
