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
    /// 屠宰批次管理
    /// </summary>
    public class KillCullService : BaseService, IKillCullService
    {
        private IKillCullAccess killCullAccess;
        private ICompanyAccess companyAccess;

        public KillCullService()
        {
            killCullAccess = BaseAccess.CreateAccess<IKillCullAccess>(AccessMappingKey.KillCullAccess.ToString());
            companyAccess = BaseAccess.CreateAccess<ICompanyAccess>(AccessMappingKey.CompanyAccess.ToString());
        }

        /// <summary>
        /// 获取KillCull总条数
        /// </summary>
        /// <returns></returns>
        public int GetKillCullCount()
        {
            int companyID = UserManagement.CurrentCompany.CompanyID;
            return killCullAccess.GetEntityCount();
        }

        /// <summary>
        /// 获取KillCull总条数
        /// </summary>
        /// <param name="code">养殖溯源码</param>
        /// <returns></returns>
        public int GetKillCullCount(string code)
        {
            int companyID = UserManagement.CurrentCompany.CompanyID;
            return killCullAccess.GetEntityCount(companyID, code);
        }

        /// <summary>
        /// 获取当前用户的所在公司的屠宰批次信息（分页）
        /// </summary>
        /// <param name="code">养殖溯源码</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        public List<KillCullModel> GetPagerKillCull(string code, int pageIndex, int pageSize)
        {
            int companyID = UserManagement.CurrentCompany.CompanyID;
            var result = killCullAccess.GetPagerKillCullByConditions(companyID, code.Trim(), pageIndex, pageSize);
            //result.ForEach(m => SetLandBase(m));
            return result;
        }

        /// <summary>
        /// 通过ID获取KillCull
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public KillCullModel GetKillCullById(int id)
        {
            return killCullAccess.GetEntityById(id);
        }

        /// <summary>
        /// 新增单条KillCull
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        public MessageModel InsertSingleKillCull(KillCullModel model)
        {
            return killCullAccess.InsertSingleEntity(model);
        }

        /// <summary>
        /// 编辑单条KillCull
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        public MessageModel UpdateSingleKillCull(KillCullModel model)
        {
            return killCullAccess.UpdateSingleEntity(model);
        }

        /// <summary>
        /// 删除单条KillCull
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public MessageModel DeleteSingleKillCull(int id)
        {
            return killCullAccess.DeleteSingleEntity(id);
        }

        public KillCullModel GetKillCullByEPCOrORCode(string Epc, string OrCode)
        {
            KillCullAccess access = new KillCullAccess();
            return access.GetKillCullByEPCOrORCode(Epc, OrCode);
        }

        //private void SetLandBase(KillCullModel model)
        //{
        //    if (model.CompanyID.HasValue)
        //        model.Company = companyAccess.GetEntityById(model.CompanyID.Value);
        //}
    }
}
