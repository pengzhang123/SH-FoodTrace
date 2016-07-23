using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IService
{
    public interface ICountryService
    {
        /// <summary>
        /// 获取Country总条数
        /// </summary>
        /// <returns></returns>
        int GetCountryCount();

        /// <summary>
        /// 获取Country总条数
        /// </summary>
        /// <param name="provinceId">查询条件：城市ID（精确查询）</param>
        /// <param name="name">查询条件：区县名称（模糊查询）</param>
        /// <returns></returns>
        int GetCountryCount(int? cityId, string name);

        /// <summary>
        /// 获取区县信息（分页）
        /// </summary>
        /// <param name="areaId">查询条件：城市ID（精确查询）</param>
        /// <param name="name">查询条件：区县名称（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        List<CountryModel> GetPagerCountry(int? cityId, string name, int pageIndex, int pageSize);

        /// <summary>
        /// 通过ID获取Country
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CountryModel GetCountryById(int id);

        /// <summary>
        /// 新增单条Country
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel InsertSingleCountry(CountryModel model);

        /// <summary>
        /// 编辑单条Country
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel UpdateSingleCountry(CountryModel model);

        /// <summary>
        /// 删除单条Country
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        MessageModel DeleteSingleCountry(int id);
    }
}
