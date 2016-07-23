using FoodTrace.Common.Libraries;
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
    /// <summary>
    /// 基地管理
    /// </summary>
    public class LandBaseService : BaseService, ILandBaseService
    {
        private ILandBaseAccess landBaseAccess;

        public LandBaseService()
        {
            landBaseAccess = BaseAccess.CreateAccess<ILandBaseAccess>(AccessMappingKey.LandBaseAccess.ToString());
        }

        /// <summary>
        /// 获取LandBase总条数
        /// </summary>
        /// <returns></returns>
        public int GetLandBaseCount()
        {
            return landBaseAccess.GetEntityCount();
        }

        /// <summary>
        /// 获取LandBase总条数
        /// </summary>
        /// <param name="name">查询条件：基地名称（模糊查询）</param>
        /// <returns></returns>
        public int GetLandBaseCount(string name)
        {
            int companyID = UserManagement.CurrentCompany.CompanyID;
            return landBaseAccess.GetEntityCount(companyID, name.Trim());
        }

        /// <summary>
        /// 获取当前用户的所在公司管理的基地（分页）
        /// </summary>
        /// <param name="name">查询条件：基地名称（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        public List<LandBaseModel> GetPagerLandBase(string name, int pageIndex, int pageSize)
        {
            int companyID = UserManagement.CurrentCompany.CompanyID;
            return landBaseAccess.GetPagerLandBaseByConditions(companyID, name.Trim(), pageIndex, pageSize);
        }

        /// <summary>
        /// 通过ID获取LandBase
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public LandBaseModel GetLandBaseById(int id)
        {
            return landBaseAccess.GetEntityById(id);
        }

        /// <summary>
        /// 新增单条LandBase
        /// </summary>
        /// <param name="model">基地信息实体</param>
        /// <returns></returns>
        public MessageModel InsertSingleLandBase(LandBaseModel model)
        {
            return landBaseAccess.InsertSingleEntity(model);
        }

        /// <summary>
        /// 编辑单条LandBase
        /// </summary>
        /// <param name="model">基地信息实体</param>
        /// <returns></returns>
        public MessageModel UpdateSingleLandBase(LandBaseModel model)
        {
            return landBaseAccess.UpdateSingleEntity(model);
        }

        /// <summary>
        /// 删除单条LandBase
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public MessageModel DeleteSingleLandBase(int id)
        {
            return landBaseAccess.DeleteSingleEntity(id);
        }
    }
}
