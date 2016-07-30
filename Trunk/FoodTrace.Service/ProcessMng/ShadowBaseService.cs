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
using FoodTrace.Model.DtoModel;

namespace FoodTrace.Service
{
    /// <summary>
    /// 成品皮影加工基本信息管理
    /// </summary>
    public class ShadowBaseService:BaseService, IShadowBaseService
    {
        private IShadowBaseAccess shadowBaseAccess;

        public ShadowBaseService()
        {
            shadowBaseAccess = BaseAccess.CreateAccess<IShadowBaseAccess>(AccessMappingKey.ShadowBaseAccess.ToString());
        }

        /// <summary>
        /// 获取ShadowBase总条数
        /// </summary>
        /// <returns></returns>
        public int GetShadowBaseCount()
        {
            return shadowBaseAccess.GetEntityCount();
        }

        /// <summary>
        /// 获取ShadowBase总条数
        /// </summary>
        /// <param name="code">查询条件：皮影溯源码（模糊查询）</param>
        /// <returns></returns>
        public int GetShadowBaseCount(string code)
        {
            int companyID = UserManagement.CurrentUser.CompanyId;
            return shadowBaseAccess.GetEntityCount(companyID, code.Trim());
        }

        /// <summary>
        /// 获取当前用户所在公司的成品皮影加工基本信息（分页）
        /// </summary>
        /// <param name="code">查询条件：皮影溯源码（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        public List<ShadowBaseModel> GetPagerShadowBase(string code, int pageIndex, int pageSize)
        {
            int companyID = UserManagement.CurrentUser.CompanyId;
            var result = shadowBaseAccess.GetPagerShadowBaseByConditions(companyID, code.Trim(), pageIndex, pageSize);
            return result;
        }

        /// <summary>
        /// 通过ID获取ShadowBase
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ShadowBaseModel GetShadowBaseById(int id)
        {
            return shadowBaseAccess.GetEntityById(id);
        }

        /// <summary>
        /// 新增单条ShadowBase
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        public MessageModel InsertSingleShadowBase(ShadowBaseModel model)
        {
            return shadowBaseAccess.InsertSingleEntity(model);
        }

        /// <summary>
        /// 编辑单条ShadowBase
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        public MessageModel UpdateSingleShadowBase(ShadowBaseModel model)
        {
            return shadowBaseAccess.UpdateSingleEntity(model);
        }

        /// <summary>
        /// 删除单条ShadowBase
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public MessageModel DeleteSingleShadowBase(int id)
        {
            return shadowBaseAccess.DeleteSingleEntity(id);
        }

        public ShadowBaseModel GetShawInfoByEPCOrORCode(string Epc, string OrCode)
        {
            ShadowBaseAccess access = new ShadowBaseAccess();
            return access.GetShawInfoByEPCOrORCode(Epc, OrCode);
        }

        public ShadowBaseModel GetShawInfoByChipCode(string chipCode)
        {
            ShadowBaseAccess access = new ShadowBaseAccess();
            return access.GetShawInfoByChipCode(chipCode);
        }

        /// <summary>
        /// 皮影的基本信息
        /// </summary>
        /// <param name="epc"></param>
        /// <param name="orCode"></param>
        /// <returns></returns>
        public ShadowBaseDto GetShadowByEpcOrCode(string epc, string orCode)
        {
            ShadowBaseAccess access = new ShadowBaseAccess();
            return access.GetShadowByEpcOrCode(epc, orCode);
        }
    }
}
