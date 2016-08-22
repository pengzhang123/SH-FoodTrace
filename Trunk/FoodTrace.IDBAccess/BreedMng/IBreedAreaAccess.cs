using FoodTrace.Model;
using System.Collections.Generic;
using FoodTrace.Model.BaseDto;
using FoodTrace.Model.DtoModel;

namespace FoodTrace.IDBAccess
{
    public interface IBreedAreaAccess : IBaseAccess<BreedAreaModel>
    {
        List<BreedAreaModel> GetPagerBreedAreaByConditions(int companyID, string name, int pageIndex, int pageSize);
        int GetEntityCount(int companyID, string name);

        /// <summary>
        /// 分页数据
        /// </summary>
        /// <param name="comId"></param>
        /// <param name="pIndex"></param>
        /// <param name="pSize"></param>
        /// <returns></returns>
        GridList<BreedAreaDto> GetAreaGridList(int comId, int pIndex, int pSize);

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
        BreedAreaDto GetAreaDtoById(int id);
    }
}
