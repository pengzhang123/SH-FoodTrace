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
    /// 加工厂接收待加工订单信息管理
    /// </summary>
    public class ProcessBatchService : BaseService, IProcessBatchService
    {
        private IProcessBatchAccess processBatchAccess;

        public ProcessBatchService()
        {
            processBatchAccess = BaseAccess.CreateAccess<IProcessBatchAccess>(AccessMappingKey.ProcessBatchAccess.ToString());
        }

        /// <summary>
        /// 获取ProcessBatch总条数
        /// </summary>
        /// <returns></returns>
        public int GetProcessBatchCount()
        {
            return processBatchAccess.GetEntityCount();
        }

        /// <summary>
        /// 获取ProcessBatch总条数
        /// </summary>
        /// <param name="batchNo">查询条件：批次编号（模糊查询）</param>
        /// <returns></returns>
        public int GetProcessBatchCount(string batchNo)
        {
            int companyID = UserManagement.CurrentUser.CompanyId;
            return processBatchAccess.GetEntityCount(companyID, batchNo.Trim());
        }

        /// <summary>
        /// 获取当前用户所在公司的待加工订单信息（分页）
        /// </summary>
        /// <param name="batchNo">查询条件：批次编号（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        public List<ProcessBatchModel> GetPagerProcessBatch(string batchNo, int pageIndex, int pageSize)
        {
            int companyID = UserManagement.CurrentUser.CompanyId;
            var result = processBatchAccess.GetPagerProcessBatchByConditions(companyID, batchNo.Trim(), pageIndex, pageSize);
            return result;
        }

        /// <summary>
        /// 通过ID获取ProcessBatch
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProcessBatchModel GetProcessBatchById(int id)
        {
            return processBatchAccess.GetEntityById(id);
        }

        /// <summary>
        /// 新增单条ProcessBatch
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        public MessageModel InsertSingleProcessBatch(ProcessBatchModel model)
        {
            return processBatchAccess.InsertSingleEntity(model);
        }

        /// <summary>
        /// 编辑单条ProcessBatch
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        public MessageModel UpdateSingleProcessBatch(ProcessBatchModel model)
        {
            return processBatchAccess.UpdateSingleEntity(model);
        }

        /// <summary>
        /// 删除单条ProcessBatch
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public MessageModel DeleteSingleProcessBatch(int id)
        {
            return processBatchAccess.DeleteSingleEntity(id);
        }

    }
}
