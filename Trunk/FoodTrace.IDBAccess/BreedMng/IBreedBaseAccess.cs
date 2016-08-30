using FoodTrace.Model;
using System.Collections.Generic;
using FoodTrace.Model.BaseDto;
using FoodTrace.Model.DtoModel;

namespace FoodTrace.IDBAccess
{
    public interface IBreedBaseAccess : IBaseAccess<BreedBaseModel>
    {
        int GetEntityCount(int companyID, string name);
        List<BreedBaseModel> GetPagerBreedBaseByConditions(int companyID, string name, int pageIndex, int pageSize);
        //BreedBaseModel GetBreedInfoByEPCOrORCode(string Epc, string OrCode);

        /// <summary>
        /// 分页数据
        /// </summary>
        /// <param name="comid"></param>
        /// <param name="pIndex"></param>
        /// <param name="pSize"></param>
        /// <returns></returns>
        GridList<BreedBaseDto> GetBreedBaseListPaging(int comid, string name, int pIndex, int pSize);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        MessageModel DeleteByIds(string ids);

        /// <summary>
        /// 根据id获取数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
       BreedBaseDto GetBreedBaseDtoById(int id);
    }
}
