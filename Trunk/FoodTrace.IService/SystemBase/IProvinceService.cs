using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IService
{
    public interface IProvinceService
    {
        /// <summary>
        /// 获取Province总条数
        /// </summary>
        /// <returns></returns>
        int GetProvinceCount();

        /// <summary>
        /// 获取Province总条数
        /// </summary>
        /// <param name="areaId">查询条件：区域ID（精确查询）</param>
        /// <param name="name">查询条件：省份名称（模糊查询）</param>
        /// <returns></returns>
        int GetProvinceCount(int? areaId, string name);

        /// <summary>
        /// 获取省份信息（分页）
        /// </summary>
        /// <param name="areaId">查询条件：区域ID（精确查询）</param>
        /// <param name="name">查询条件：省份名称（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        List<ProvinceModel> GetPagerProvince(int? areaId, string name, int pageIndex, int pageSize);

        /// <summary>
        /// 通过ID获取Province
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ProvinceModel GetProvinceById(int id);

        /// <summary>
        /// 新增单条Province
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel InsertSingleProvince(ProvinceModel model);

        /// <summary>
        /// 编辑单条Province
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel UpdateSingleProvince(ProvinceModel model);

        /// <summary>
        /// 删除单条Province
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        MessageModel DeleteSingleProvince(int id);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        MessageModel DeleteByIds(string ids);
    }
}
