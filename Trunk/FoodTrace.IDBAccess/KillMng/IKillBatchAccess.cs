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
    public interface IKillBatchAccess : IBaseAccess<KillBatchModel>
    {
        int GetEntityCount(int companyID, string code);

        List<KillBatchModel> GetPagerKillBatchByConditions(int companyID,string code, int pageIndex, int pageSize);

        /// <summary>
        /// 获取单条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        KillBatchDto GetKillBatchDtoById(int id);

        /// <summary>
        /// 屠宰批次列表
        /// </summary>
        /// <param name="comId"></param>
        /// <param name="pIndex"></param>
        /// <param name="pSize"></param>
        /// <returns></returns>
        GridList<KillBatchDto> GetKillBatchListPaging(int comId, int pIndex, int pSize);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        MessageModel DeleteByIds(string ids);
    }
}
