using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTrace.Model.BaseDto;
using FoodTrace.Model.DtoModel;

namespace FoodTrace.IDBAccess
{
    public interface IKillDrugAccess : IBaseAccess<KillDrugModel>
    {
        int GetEntityCount(int companyID, string code);

        List<KillDrugModel> GetPagerKillDrugByConditions(int companyID, string code, int pageIndex, int pageSize);

        /// <summary>
        /// 分页数据
        /// </summary>
        /// <param name="comid"></param>
        /// <param name="pIndex"></param>
        /// <param name="pSize"></param>
        /// <returns></returns>
        GridList<KillDrugDto> GetKillDrugListPaging(int comid, int pIndex, int pSize);
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        MessageModel DeleteByIds(string ids);

        /// <summary>
        /// 根据id获取数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        KillDrugDto GetKillDrugDtoById(int id);
    }
}
