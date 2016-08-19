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
    public interface IKillBatchDetailAccess : IBaseAccess<KillBatchDetailModel>
    {
        int GetEntityCount(int companyID, string code);

        List<KillBatchDetailModel> GetPagerKillBatchDetailByConditions(int companyID, string code, int pageIndex, int pageSize);

        List<KillBatchDetailModel> GetAllEntities(int batchId);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        MessageModel DeleteByIds(string ids);

        /// <summary>
        /// 根据id获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        KillBatchDetailDto GetKillBatchDetalDtoById(int id);

        /// <summary>
        /// 获取数据分页
        /// </summary>
        /// <param name="epc"></param>
        /// <param name="comId"></param>
        /// <param name="pIndex"></param>
        /// <param name="pSize"></param>
        /// <returns></returns>
        GridList<KillBatchDetailDto> GetKillBatchDetailListPaging(string epc, int comId, int pIndex, int pSize);
    }
}
