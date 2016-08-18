using FoodTrace.Model;
using System.Collections.Generic;
using FoodTrace.Model.BaseDto;
using FoodTrace.Model.DtoModel;

namespace FoodTrace.IDBAccess
{
    public interface IPlansBatchAccess : IBaseAccess<PlansBatchModel>
    {
        int GetEntityCount(int companyID, string code);

        List<PlansBatchModel> GetPagerPlansBatchByConditions(int companyID, string code, int pageIndex, int pageSize);
        PlansBatchModel GetPlansBatchByEPCOrORCode(string Epc, string OrCode);

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="pIndex"></param>
        /// <param name="pSize"></param>
        /// <returns></returns>
        GridList<PlatPlanDto> GetPlatPlanList(int pIndex, int pSize);

        /// <summary>
        /// 根据id获取数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        PlatPlanDto GetPlatPlanDtoById(int id);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        MessageModel DleteByIds(string ids);
    }
}
