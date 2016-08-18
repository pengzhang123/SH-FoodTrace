using FoodTrace.Model;
using System.Collections.Generic;
using FoodTrace.Model.BaseDto;
using FoodTrace.Model.DtoModel;

namespace FoodTrace.IDBAccess
{
    public interface IPlansDrugAccess : IBaseAccess<PlansDrugModel>
    {
        int GetEntityCount(int companyID, string code);

        List<PlansDrugModel> GetPagerPlansDrugByConditions(int companyID, string code, int pageIndex, int pageSize);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        MessageModel DeleteByIds(string ids);

        /// <summary>
        /// 根据Id获取数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        PlantDrugDto GetPlantDrugDtoById(int id);

        /// <summary>
        /// 分页数据
        /// </summary>
        /// <param name="comId"></param>
        /// <param name="pIndex"></param>
        /// <param name="pSize"></param>
        /// <returns></returns>
        GridList<PlantDrugDto> GetPlanDrugList(int comId, int pIndex, int pSize);
    }
}
