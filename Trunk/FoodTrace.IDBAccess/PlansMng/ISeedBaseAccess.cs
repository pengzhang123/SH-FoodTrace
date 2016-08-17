using FoodTrace.Model;
using System.Collections.Generic;
using FoodTrace.Model.BaseDto;
using FoodTrace.Model.DtoModel;

namespace FoodTrace.IDBAccess
{
    public interface ISeedBaseAccess : IBaseAccess<SeedBaseModel>
    {
        int GetEntityCount(string name);

        List<SeedBaseModel> GetPagerSeedBaseByConditions(string name, int pageIndex, int pageSize);

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pIndex"></param>
        /// <param name="pSize"></param>
        /// <returns></returns>
        GridList<SeedDto> GetSeedPagingList(string name, int pIndex, int pSize);

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
        SeedDto GetSeedDtoById(int id);
    }
}
