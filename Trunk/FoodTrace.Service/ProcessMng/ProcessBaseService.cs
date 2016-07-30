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
    /// 生产加工工序基本信息管理
    /// </summary>
    public class ProcessBaseService : BaseService, IProcessBaseService
    {
        private IProcessBaseAccess processBaseAccess;

        public ProcessBaseService()
        {
            processBaseAccess = BaseAccess.CreateAccess<IProcessBaseAccess>(AccessMappingKey.ProcessBaseAccess.ToString());
        }

        /// <summary>
        /// 获取ProcessBase总条数
        /// </summary>
        /// <returns></returns>
        public int GetProcessBaseCount()
        {
            return processBaseAccess.GetEntityCount();
        }

        /// <summary>
        /// 获取ProcessBase总条数
        /// </summary>
        /// <param name="name">查询条件：工序名称（模糊查询）</param>
        /// <returns></returns>
        public int GetProcessBaseCount(string name)
        {
            int companyID = UserManagement.CurrentUser.CompanyId;
            return processBaseAccess.GetEntityCount(name.Trim());
        }

        /// <summary>
        /// 获取生产加工工序基本信息（分页）
        /// </summary>
        /// <param name="name">查询条件：工序名称（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        public List<ProcessBaseModel> GetPagerProcessBase(string name, int pageIndex, int pageSize)
        {
            int companyID = UserManagement.CurrentUser.CompanyId;
            var result = processBaseAccess.GetPagerProcessBaseByConditions(name.Trim(), pageIndex, pageSize);
            return result;
        }

        /// <summary>
        /// 通过ID获取ProcessBase
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProcessBaseModel GetProcessBaseById(int id)
        {
            return processBaseAccess.GetEntityById(id);
        }

        /// <summary>
        /// 新增单条ProcessBase
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        public MessageModel InsertSingleProcessBase(ProcessBaseModel model)
        {
            return processBaseAccess.InsertSingleEntity(model);
        }

        /// <summary>
        /// 编辑单条ProcessBase
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        public MessageModel UpdateSingleProcessBase(ProcessBaseModel model)
        {
            return processBaseAccess.UpdateSingleEntity(model);
        }

        /// <summary>
        /// 删除单条ProcessBase
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public MessageModel DeleteSingleProcessBase(int id)
        {
            return processBaseAccess.DeleteSingleEntity(id);
        }

    }
}
