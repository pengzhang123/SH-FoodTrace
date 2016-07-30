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
    public class KillBatchService : BaseService, IKillBatchService
    {
        private IKillBatchAccess killBatchAccess;
        private IKillBatchDetailAccess killBatchDetailAccess;
        private ICompanyAccess companyAccess;

        public KillBatchService()
        {
            killBatchAccess = BaseAccess.CreateAccess<IKillBatchAccess>(AccessMappingKey.KillBatchAccess.ToString());
            killBatchDetailAccess = BaseAccess.CreateAccess<IKillBatchDetailAccess>(AccessMappingKey.KillBatchDetailAccess.ToString());
            companyAccess = BaseAccess.CreateAccess<ICompanyAccess>(AccessMappingKey.CompanyAccess.ToString());
        }

        /// <summary>
        /// 获取KillBatch总条数
        /// </summary>
        /// <returns></returns>
        public int GetKillBatchCount()
        {
            return killBatchAccess.GetEntityCount();
        }

        /// <summary>
        /// 获取KillBatch总条数
        /// </summary>
        /// <param name="code">查询条件：批次编号（模糊查询）</param>
        /// <returns></returns>
        public int GetKillBatchCount(string code)
        {
            int companyID = UserManagement.CurrentUser.CompanyId;
            return killBatchAccess.GetEntityCount(companyID, code.Trim());
        }

        /// <summary>
        /// 获取当前用户的所在公司管理的屠宰批次信息（分页）
        /// </summary>
        /// <param name="code">查询条件：批次编号（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        public List<KillBatchModel> GetPagerKillBatch(string code, int pageIndex, int pageSize)
        {
            int companyID = UserManagement.CurrentUser.CompanyId;
            var result = killBatchAccess.GetPagerKillBatchByConditions(companyID, code.Trim(), pageIndex, pageSize);
            //result.ForEach(m => SetCompany(m));
            return result;
        }

        /// <summary>
        /// 通过ID获取KillBatch
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public KillBatchModel GetKillBatchById(int id)
        {
            var result = killBatchAccess.GetEntityById(id);
            result.KillBatchDetail = killBatchDetailAccess.GetAllEntities(id);
            return result;

        }

        /// <summary>
        /// 新增单条KillBatch
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        public MessageModel InsertSingleKillBatch(KillBatchModel model)
        {
            return killBatchAccess.InsertSingleEntity(model);
        }

        /// <summary>
        /// 编辑单条KillBatch
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        public MessageModel UpdateSingleKillBatch(KillBatchModel model)
        {
            return killBatchAccess.UpdateSingleEntity(model);
        }

        /// <summary>
        /// 删除单条KillBatch
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public MessageModel DeleteSingleKillBatch(int id)
        {
            return killBatchAccess.DeleteSingleEntity(id);
        }


        //private void SetCompany(KillBatchModel model)
        //{
        //    if (model.CompanyID.HasValue)
        //        model.Company = companyAccess.GetEntityById(model.CompanyID.Value);
        //}
    }
}
