using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTrace.Model.BaseDto;
using FoodTrace.Model.DtoModel;

namespace FoodTrace.IDBAccess
{
    public interface IProvinceAccess : IBaseAccess<ProvinceModel>
    {
        int GetEntityCount(int? areaId, string name);

        List<ProvinceModel> GetPagerProvinceByConditions(int? areaId, string name, int pageIndex, int pageSize);

        GridList<ProviceDto> GetProviceListPaging(int? areaId, string name, int pageIndex, int pageSize);
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
       MessageModel DeleteByIds(string ids);
    }
}
