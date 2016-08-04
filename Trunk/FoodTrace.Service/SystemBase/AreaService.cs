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
    public class AreaService : BaseService, IAreaService
    {
        private IAreaAccess areaAccess;

        public AreaService()
        {
            areaAccess = BaseAccess.CreateAccess<IAreaAccess>(AccessMappingKey.AreaAccess.ToString());
        }

        /// <summary>
        /// 获取Area总条数
        /// </summary>
        /// <returns></returns>
        public int GetAreaCount()
        {
            return areaAccess.GetEntityCount();
        }

        /// <summary>
        /// 获取Area总条数
        /// </summary>
        /// <param name="name">查询条件：菜单名称（模糊查询）</param>
        /// <returns></returns>
        public int GetAreaCount(string name)
        {
            return areaAccess.GetEntityCount(name.Trim());
        }

        /// <summary>
        /// 获取区域信息（分页）
        /// </summary>
        /// <param name="name">查询条件：区域名称（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        public List<AreaModel> GetPagerArea(string name, int pageIndex, int pageSize)
        {
            return areaAccess.GetPagerAreaByConditions(name.Trim(), pageIndex, pageSize);
        }

        /// <summary>
        /// 通过ID获取Area
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AreaModel GetAreaById(int id)
        {
            return areaAccess.GetEntityById(id);
        }

        /// <summary>
        /// 新增单条Area
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        public MessageModel InsertSingleArea(AreaModel model)
        {
            return areaAccess.InsertSingleEntity(model);
        }

        /// <summary>
        /// 编辑单条Area
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        public MessageModel UpdateSingleArea(AreaModel model)
        {
            return areaAccess.UpdateSingleEntity(model);
        }

        /// <summary>
        /// 删除单条Area
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public MessageModel DeleteSingleArea(int id)
        {
            return areaAccess.DeleteSingleEntity(id);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public MessageModel DeleteAreaByIds(string ids)
        {
            return areaAccess.DeleteAreaByIds(ids);
        }
    }
}
