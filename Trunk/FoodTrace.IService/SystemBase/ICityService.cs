using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IService
{
    public interface ICityService
    {
        /// <summary>
        /// 获取City总条数
        /// </summary>
        /// <returns></returns>
        int GetCityCount();

        /// <summary>
        /// 获取City总条数
        /// </summary>
        /// <param name="provinceId">查询条件：省份ID（精确查询）</param>
        /// <param name="name">查询条件：城市名称（模糊查询）</param>
        /// <returns></returns>
        int GetCityCount(int? provinceId, string name);

        /// <summary>
        /// 获取城市信息（分页）
        /// </summary>
        /// <param name="areaId">查询条件：省份ID（精确查询）</param>
        /// <param name="name">查询条件：城市名称（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        List<CityModel> GetPagerCity(int? provinceId, string name, int pageIndex, int pageSize);

        /// <summary>
        /// 通过ID获取City
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CityModel GetCityById(int id);

        /// <summary>
        /// 新增单条City
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel InsertSingleCity(CityModel model);

        /// <summary>
        /// 编辑单条City
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel UpdateSingleCity(CityModel model);

        /// <summary>
        /// 删除单条City
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        MessageModel DeleteSingleCity(int id);
    }
}
