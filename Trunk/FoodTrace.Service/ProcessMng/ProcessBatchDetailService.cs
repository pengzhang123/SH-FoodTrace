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
    /// 加工厂接收的加工明细信息管理
    /// </summary>
    public class ProcessBatchDetailService : BaseService, IProcessBatchDetailService
    {
        private IProcessBatchDetailAccess processBatchDetailAccess;

        public ProcessBatchDetailService()
        {
            processBatchDetailAccess = BaseAccess.CreateAccess<IProcessBatchDetailAccess>(AccessMappingKey.ProcessBatchDetailAccess.ToString());
        }

        /// <summary>
        /// 获取ProcessBatchDetail总条数
        /// </summary>
        /// <returns></returns>
        public int GetProcessBatchDetailCount()
        {
            return processBatchDetailAccess.GetEntityCount();
        }

        /// <summary>
        /// 获取ProcessBatchDetail总条数
        /// </summary>
        /// <param name="code">查询条件：批次编号（模糊查询）</param>
        /// <returns></returns>
        public int GetProcessBatchDetailCount(string code)
        {
            int companyID = UserManagement.CurrentUser.CompanyId;
            return processBatchDetailAccess.GetEntityCount(companyID, code.Trim());
        }

        /// <summary>
        /// 获取当前用户所在公司的加工明细信息管理（分页）
        /// </summary>
        /// <param name="code">查询条件：批次编号（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        public List<ProcessBatchDetailModel> GetPagerProcessBatchDetail(string code, int pageIndex, int pageSize)
        {
            int companyID = UserManagement.CurrentUser.CompanyId;
            var result = processBatchDetailAccess.GetPagerProcessBatchDetailByConditions(companyID, code.Trim(), pageIndex, pageSize);
            return result;
        }

        /// <summary>
        /// 通过ID获取ProcessBatchDetail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProcessBatchDetailModel GetProcessBatchDetailById(int id)
        {
            return processBatchDetailAccess.GetEntityById(id);
        }

        /// <summary>
        /// 新增单条ProcessBatchDetail
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        public MessageModel InsertSingleProcessBatchDetail(ProcessBatchDetailModel model)
        {
            return processBatchDetailAccess.InsertSingleEntity(model);
        }

        /// <summary>
        /// 编辑单条ProcessBatchDetail
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        public MessageModel UpdateSingleProcessBatchDetail(ProcessBatchDetailModel model)
        {
            return processBatchDetailAccess.UpdateSingleEntity(model);
        }

        /// <summary>
        /// 删除单条ProcessBatchDetail
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public MessageModel DeleteSingleProcessBatchDetail(int id)
        {
            return processBatchDetailAccess.DeleteSingleEntity(id);
        }

    }
}
