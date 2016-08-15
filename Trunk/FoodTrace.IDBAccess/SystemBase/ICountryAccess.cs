using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTrace.Model.BaseDto;

namespace FoodTrace.IDBAccess
{
    public interface ICountryAccess : IBaseAccess<CountryModel>
    {
        int GetEntityCount(int? cityId, string name);
        List<CountryModel> GetPagerCountryByConditions(int? cityId, string name, int pageIndex, int pageSize);
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        MessageModel DeleteByIds(string ids);

        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <param name="cityId"></param>
        /// <param name="name"></param>
        /// <param name="pIndex"></param>
        /// <param name="pSize"></param>
        /// <returns></returns>
        GridList<CountryDto> GetCountryListPaging(int? cityId, string name, int pIndex, int pSize);
    }
}
