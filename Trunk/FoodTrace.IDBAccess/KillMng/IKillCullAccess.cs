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
    public interface IKillCullAccess : IBaseAccess<KillCullModel>
    {
        int GetEntityCount(int companyID, string code);

        List<KillCullModel> GetPagerKillCullByConditions(int companyID, string code, int pageIndex, int pageSize);
        KillCullModel GetKillCullByEPCOrORCode(string Epc, string OrCode);

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="comId"></param>
        /// <param name="pIndex"></param>
        /// <param name="pSize"></param>
        /// <returns></returns>
        GridList<KillCullDto> GetKillCullListPaging(int comId, int pIndex, int pSize);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        MessageModel DeleteByIds(string ids);

        /// <summary>
        /// 获取个人信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        KillCullDto GetKillCullDtoById(int id);
    }
}
