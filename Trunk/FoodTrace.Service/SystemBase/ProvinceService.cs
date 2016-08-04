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
    public class ProvinceService : BaseService, IProvinceService
    {
        private IProvinceAccess provinceAccess;

        public ProvinceService()
        {
            provinceAccess = BaseAccess.CreateAccess<IProvinceAccess>(AccessMappingKey.ProvinceAccess.ToString());
        }

        /// <summary>
        /// 获取Province总条数
        /// </summary>
        /// <returns></returns>
        public int GetProvinceCount()
        {
            return provinceAccess.GetEntityCount();
        }

        /// <summary>
        /// 获取Province总条数
        /// </summary>
        /// <param name="areaId">查询条件：区域ID（精确查询）</param>
        /// <param name="name">查询条件：省份名称（模糊查询）</param>
        /// <returns></returns>
        public int GetProvinceCount(int? areaId, string name)
        {
            return provinceAccess.GetEntityCount(areaId, name.Trim());
        }

        /// <summary>
        /// 获取省份信息（分页）
        /// </summary>
        /// <param name="areaId">查询条件：区域ID（精确查询）</param>
        /// <param name="name">查询条件：省份名称（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        public List<ProvinceModel> GetPagerProvince(int? areaId, string name, int pageIndex, int pageSize)
        {
            return provinceAccess.GetPagerProvinceByConditions(areaId, name.Trim(), pageIndex, pageSize);
        }

        /// <summary>
        /// 通过ID获取Province
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProvinceModel GetProvinceById(int id)
        {
            return provinceAccess.GetEntityById(id);
        }

        /// <summary>
        /// 新增单条Province
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        public MessageModel InsertSingleProvince(ProvinceModel model)
        {
            return provinceAccess.InsertSingleEntity(model);
        }

        /// <summary>
        /// 编辑单条Province
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        public MessageModel UpdateSingleProvince(ProvinceModel model)
        {
            return provinceAccess.UpdateSingleEntity(model);
        }

        /// <summary>
        /// 删除单条Province
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public MessageModel DeleteSingleProvince(int id)
        {
            return provinceAccess.DeleteSingleEntity(id);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public MessageModel DeleteByIds(string ids)
        {
            return provinceAccess.DeleteByIds(ids);
        }
    }
}
