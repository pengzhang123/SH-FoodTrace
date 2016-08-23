using FoodTrace.Model;
using System.Collections.Generic;
using FoodTrace.Model.BaseDto;
using FoodTrace.Model.DtoModel;

namespace FoodTrace.IDBAccess
{
    public interface IBreedHomeAccess : IBaseAccess<BreedHomeModel>
    {
        int GetEntityCount(int companyID, string name);
        List<BreedHomeModel> GetPagerBreedHomeByConditions(int companyID, string name, int pageIndex, int pageSize);


        /// <summary>
        /// 分页数据
        /// </summary>
        /// <param name="comId"></param>
        /// <param name="pIndex"></param>
        /// <param name="pSize"></param>
        /// <returns></returns>
        GridList<BreedHomeDto> GetBreedHomeGridList(int comId, int pIndex, int pSize);

        /// <summary>
        /// 根据id获取数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        BreedHomeDto GetBreedHomeDtoById(int id);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        MessageModel DeleteByIds(string ids);
    }
}

