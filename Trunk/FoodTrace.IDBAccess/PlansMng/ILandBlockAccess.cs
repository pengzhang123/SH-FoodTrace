using FoodTrace.Model;
using System.Collections.Generic;
using System.Linq;
using FoodTrace.Model.BaseDto;
using FoodTrace.Model.DtoModel;

namespace FoodTrace.IDBAccess
{
    /// <summary>
    /// 种植企业基地地块管理
    /// </summary>
    public interface ILandBlockAccess : IBaseAccess<LandBlockModel>
    {
        int GetEntityCount(int companyID, string name);

        List<LandBlockModel> GetPagerLandBlockByConditions(int companyID, string name, int pageIndex, int pageSize);

        //IQueryable<LandBlockModel> GetAllEntities1();

        /// <summary>
        /// 数据分页
        /// </summary>
        /// <param name="comId"></param>
        /// <param name="name"></param>
        /// <param name="pIndex"></param>
        /// <param name="pSize"></param>
        /// <returns></returns>
        GridList<LandBlockDto> GetLandBlockPaging(int comId, string name, int pIndex, int pSize);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        MessageModel DeleteByIds(string ids);

        /// <summary>
        /// 根据id获取地块名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        LandBlockDto GetLandBlockById(int id);
    }
}
