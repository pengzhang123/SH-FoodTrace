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
    public class AreaPlatService : BaseService, IAreaPlatService
    {
        private IAreaPlatAccess areaPlatAccess;

        public AreaPlatService()
        {
            areaPlatAccess = BaseAccess.CreateAccess<IAreaPlatAccess>(AccessMappingKey.AreaPlatAccess.ToString());
        }

        /// <summary>
        /// 获取AreaPlat总条数
        /// </summary>
        /// <returns></returns>
        public int GetAreaPlatCount()
        {
            return areaPlatAccess.GetEntityCount();
        }

        /// <summary>
        /// 获取AreaPlat总条数
        /// </summary>        
        /// <param name="name">查询条件：平台代码（模糊查询）</param>
        /// <returns></returns>
        public int GetAreaPlatCount( string name)
        {
            return areaPlatAccess.GetEntityCount(name.Trim());
        }

        /// <summary>
        /// 获取城市信息（分页）
        /// </summary>
        /// <param name="name">查询条件：平台代码名称（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        public List<AreaPlatModel> GetPagerAreaPlat(string name, int pageIndex, int pageSize)
        {
            return areaPlatAccess.GetPagerAreaPlatByConditions(name.Trim(), pageIndex, pageSize);
        }

        /// <summary>
        /// 通过ID获取AreaPlat
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AreaPlatModel GetAreaPlatById(int id)
        {
            return areaPlatAccess.GetEntityById(id);
        }

        /// <summary>
        /// 新增单条AreaPlat
        /// </summary>
        /// <param name="model">平台代码信息实体</param>
        /// <returns></returns>
        public MessageModel InsertSingleAreaPlat(AreaPlatModel model)
        {
            return areaPlatAccess.InsertSingleEntity(model);
        }

        /// <summary>
        /// 编辑单条AreaPlat
        /// </summary>
        /// <param name="model">平台代码信息实体</param>
        /// <returns></returns>
        public MessageModel UpdateSingleAreaPlat(AreaPlatModel model)
        {
            return areaPlatAccess.UpdateSingleEntity(model);
        }

        /// <summary>
        /// 删除单条AreaPlat
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public MessageModel DeleteSingleAreaPlat(int id)
        {
            return areaPlatAccess.DeleteSingleEntity(id);
        }
    }
}
