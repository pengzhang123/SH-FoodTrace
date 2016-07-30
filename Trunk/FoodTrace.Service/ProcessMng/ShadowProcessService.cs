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
    /// 皮影加工对应的工序信息管理
    /// </summary>
    public class ShadowProcessService : BaseService, IShadowProcessService
    {
        private IShadowProcessAccess shadowProcessAccess;

        public ShadowProcessService()
        {
            shadowProcessAccess = BaseAccess.CreateAccess<IShadowProcessAccess>(AccessMappingKey.ShadowProcessAccess.ToString());
        }

        /// <summary>
        /// 获取ShadowProcess总条数
        /// </summary>
        /// <returns></returns>
        public int GetShadowProcessCount()
        {
            return shadowProcessAccess.GetEntityCount();
        }

        /// <summary>
        /// 获取ShadowProcess总条数
        /// </summary>
        /// <param name="code">查询条件：加工批次（模糊查询）</param>
        /// <returns></returns>
        public int GetShadowProcessCount(string code)
        {
            int companyID = UserManagement.CurrentUser.CompanyId;
            return shadowProcessAccess.GetEntityCount(companyID, code.Trim());
        }

        /// <summary>
        /// 获取当前用户所在公司的皮影加工对应的工序信息（分页）
        /// </summary>
        /// <param name="code">查询条件：加工批次（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        public List<ShadowProcessModel> GetPagerShadowProcess(string code, int pageIndex, int pageSize)
        {
            int companyID = UserManagement.CurrentUser.CompanyId;
            var result = shadowProcessAccess.GetPagerShadowProcessByConditions(companyID, code.Trim(), pageIndex, pageSize);
            return result;
        }

        /// <summary>
        /// 通过ID获取ShadowProcess
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ShadowProcessModel GetShadowProcessById(int id)
        {
            return shadowProcessAccess.GetEntityById(id);
        }

        /// <summary>
        /// 新增单条ShadowProcess
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        public MessageModel InsertSingleShadowProcess(ShadowProcessModel model)
        {
            return shadowProcessAccess.InsertSingleEntity(model);
        }

        /// <summary>
        /// 编辑单条ShadowProcess
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        public MessageModel UpdateSingleShadowProcess(ShadowProcessModel model)
        {
            return shadowProcessAccess.UpdateSingleEntity(model);
        }

        /// <summary>
        /// 删除单条ShadowProcess
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public MessageModel DeleteSingleShadowProcess(int id)
        {
            return shadowProcessAccess.DeleteSingleEntity(id);
        }

    }
}
