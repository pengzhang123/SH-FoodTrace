using FoodTrace.DBAccess;
using FoodTrace.IDBAccess;
using FoodTrace.IService;
using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTrace.Model.BaseDto;

namespace FoodTrace.Service
{
    public class CountryService : BaseService, ICountryService
    {
        private ICountryAccess countryAccess;

        public CountryService()
        {
            countryAccess = BaseAccess.CreateAccess<ICountryAccess>(AccessMappingKey.CountryAccess.ToString());
        }

        /// <summary>
        /// 获取Country总条数
        /// </summary>
        /// <returns></returns>
        public int GetCountryCount()
        {
            return countryAccess.GetEntityCount();
        }

        /// <summary>
        /// 获取Country总条数
        /// </summary>
        /// <param name="provinceId">查询条件：城市ID（精确查询）</param>
        /// <param name="name">查询条件：区县名称（模糊查询）</param>
        /// <returns></returns>
        public int GetCountryCount(int? cityId, string name)
        {
            return countryAccess.GetEntityCount(cityId, name.Trim());
        }

        /// <summary>
        /// 获取区县信息（分页）
        /// </summary>
        /// <param name="areaId">查询条件：城市ID（精确查询）</param>
        /// <param name="name">查询条件：区县名称（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        public List<CountryModel> GetPagerCountry(int? cityId, string name, int pageIndex, int pageSize)
        {
            return countryAccess.GetPagerCountryByConditions(cityId, name.Trim(), pageIndex, pageSize);
        }

        /// <summary>
        /// 通过ID获取Country
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CountryModel GetCountryById(int id)
        {
            return countryAccess.GetEntityById(id);
        }

        /// <summary>
        /// 新增单条Country
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        public MessageModel InsertSingleCountry(CountryModel model)
        {
            return countryAccess.InsertSingleEntity(model);
        }

        /// <summary>
        /// 编辑单条Country
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        public MessageModel UpdateSingleCountry(CountryModel model)
        {
            return countryAccess.UpdateSingleEntity(model);
        }

        /// <summary>
        /// 删除单条Country
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public MessageModel DeleteSingleCountry(int id)
        {
            return countryAccess.DeleteSingleEntity(id);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public MessageModel DeleteByIds(string ids)
        {
            return countryAccess.DeleteByIds(ids);
        }

        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <param name="cityId"></param>
        /// <param name="name"></param>
        /// <param name="pIndex"></param>
        /// <param name="pSize"></param>
        /// <returns></returns>
        public GridList<CountryDto> GetCountryListPaging(int? cityId, string name, int pIndex, int pSize)
        {
            return countryAccess.GetCountryListPaging(cityId, name, pIndex, pSize);
        }
    }
}
