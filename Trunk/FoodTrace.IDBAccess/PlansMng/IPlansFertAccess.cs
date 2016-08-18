using FoodTrace.Model;
using System.Collections.Generic;
using FoodTrace.Model.BaseDto;
using FoodTrace.Model.DtoModel;

namespace FoodTrace.IDBAccess
{
    public interface IPlansFertAccess : IBaseAccess<PlansFertModel>
    {
        int GetEntityCount(int companyID, string code);

        List<PlansFertModel> GetPagerPlansFertByConditions(int companyID, string code, int pageIndex, int pageSize);

        /// <summary>
        /// 数据分页
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pIndex"></param>
        /// <param name="pSize"></param>
        /// <returns></returns>
        GridList<PlansFertDto> GetPlansFertPagingList(string name, int pIndex, int pSize);

        /// <summary>
        /// 根据id获取数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        PlansFertDto GetFerDtoById(int id);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        MessageModel DeleteByIds(string ids);

    }
}
