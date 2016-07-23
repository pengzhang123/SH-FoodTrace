using FoodTrace.DBAccess;
using FoodTrace.IDBAccess;
using FoodTrace.IService;
using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.Service
{
    public class CityService : BaseService, ICityService
    {
        private ICityAccess cityAccess;

        public CityService()
        {
            cityAccess = BaseAccess.CreateAccess<ICityAccess>(AccessMappingKey.CityAccess.ToString());
        }

        /// <summary>
        /// 获取City总条数
        /// </summary>
        /// <returns></returns>
        public int GetCityCount()
        {
            return cityAccess.GetEntityCount();
        }

        /// <summary>
        /// 获取City总条数
        /// </summary>
        /// <param name="provinceId">查询条件：省份ID（精确查询）</param>
        /// <param name="name">查询条件：城市名称（模糊查询）</param>
        /// <returns></returns>
        public int GetCityCount(int? provinceId, string name)
        {
            return cityAccess.GetEntityCount(provinceId, name.Trim());
        }

        /// <summary>
        /// 获取城市信息（分页）
        /// </summary>
        /// <param name="areaId">查询条件：省份ID（精确查询）</param>
        /// <param name="name">查询条件：城市名称（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        public List<CityModel> GetPagerCity(int? provinceId, string name, int pageIndex, int pageSize)
        {
            return cityAccess.GetPagerCityByConditions(provinceId, name.Trim(), pageIndex, pageSize);
        }

        /// <summary>
        /// 通过ID获取City
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CityModel GetCityById(int id)
        {
            return cityAccess.GetEntityById(id);
        }

        /// <summary>
        /// 新增单条City
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        public MessageModel InsertSingleCity(CityModel model)
        {
            return cityAccess.InsertSingleEntity(model);
        }

        /// <summary>
        /// 编辑单条City
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        public MessageModel UpdateSingleCity(CityModel model)
        {
            return cityAccess.UpdateSingleEntity(model);
        }

        /// <summary>
        /// 删除单条City
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public MessageModel DeleteSingleCity(int id)
        {
            return cityAccess.DeleteSingleEntity(id);
        }
    }
}
