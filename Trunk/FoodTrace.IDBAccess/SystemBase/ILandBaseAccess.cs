using FoodTrace.Model;
using System.Collections.Generic;
using FoodTrace.Model.BaseDto;
using FoodTrace.Model.DtoModel;

namespace FoodTrace.IDBAccess
{
    public interface ILandBaseAccess : IBaseAccess<LandBaseModel>
    {
        int GetEntityCount(int companyID, string name);

        List<LandBaseModel> GetPagerLandBaseByConditions(int companyID, string name, int pageIndex, int pageSize);


        /// <summary>
        /// 养殖基地分页数据
        /// </summary>
        /// <param name="compamyId"></param>
        /// <param name="pIndex"></param>
        /// <param name="pSize"></param>
        /// <returns></returns>
        GridList<LandBaseDto> GetLandBaseListPaging(int compamyId, int pIndex, int pSize, string name);

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        MessageModel DelLandBaseByIds(string ids);

        /// <summary>
        /// 根据类别获取基地1:种植,2:养殖
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        List<LandBaseDto> GetLandBaseListByType(int comId, int type);


        LandBaseModel GetLandBaseByCode(int comId, string code);
    }
}
