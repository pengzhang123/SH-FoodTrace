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
    public class TrunApplyDetailService : BaseService, ITrunApplyDetailService
    {
        private ITrunApplyDetailAccess trunApplyDetailAccess;
        private ITrunApplyAccess trunApplyAccess;
        private ICompanyAccess companyAccess;

        public TrunApplyDetailService()
        {
            trunApplyDetailAccess = BaseAccess.CreateAccess<ITrunApplyDetailAccess>(AccessMappingKey.TrunApplyDetailAccess.ToString());
            trunApplyAccess = BaseAccess.CreateAccess<ITrunApplyAccess>(AccessMappingKey.TrunApplyAccess.ToString());
            companyAccess = BaseAccess.CreateAccess<ICompanyAccess>(AccessMappingKey.CompanyAccess.ToString());
        }

        /// <summary>
        /// 获取TrunApplyDetail总条数
        /// </summary>
        /// <returns></returns>
        public int GetTrunApplyDetailCount()
        {
            return trunApplyDetailAccess.GetEntityCount();
        }

        /// <summary>
        /// 获取TrunApplyDetail总条数
        /// </summary>
        /// <param name="applyNo">查询条件：物流订单号（模糊查询）</param>
        /// <returns></returns>
        public int GetTrunApplyDetailCount(string applyNo)
        {
            int companyID = UserManagement.CurrentUser.CompanyId;
            return trunApplyDetailAccess.GetEntityCount(companyID, applyNo.Trim());
        }

        /// <summary>
        /// 获取当前用户所在公司的冷链物流运输订单明细信息（分页）
        /// </summary>
        /// <param name="applyNo">查询条件：物流订单号（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        public List<TrunApplyDetailModel> GetPagerTrunApplyDetail(string applyNo, int pageIndex, int pageSize)
        {
            int companyID = UserManagement.CurrentUser.CompanyId;
            var result = trunApplyDetailAccess.GetPagerTrunApplyDetailByConditions(companyID, applyNo.Trim(), pageIndex, pageSize);
            //result.ForEach(m => SetTrunApply(m));
            return result;
        }

        /// <summary>
        /// 通过ID获取TrunApplyDetail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TrunApplyDetailModel GetTrunApplyDetailById(int id)
        {
            return trunApplyDetailAccess.GetEntityById(id);
        }

        /// <summary>
        /// 新增单条TrunApplyDetail
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        public MessageModel InsertSingleTrunApplyDetail(TrunApplyDetailModel model)
        {
            return trunApplyDetailAccess.InsertSingleEntity(model);
        }

        /// <summary>
        /// 编辑单条TrunApplyDetail
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        public MessageModel UpdateSingleTrunApplyDetail(TrunApplyDetailModel model)
        {
            return trunApplyDetailAccess.UpdateSingleEntity(model);
        }

        /// <summary>
        /// 删除单条TrunApplyDetail
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public MessageModel DeleteSingleTrunApplyDetail(int id)
        {
            return trunApplyDetailAccess.DeleteSingleEntity(id);
        }

        public TrunApplyDetailModel GetTrunApplyDetailByEPCOrORCode(string Epc, string OrCode)
        {
            TrunApplyDetailAccess access = new TrunApplyDetailAccess();
            return access.GetTrunApplyDetailByEPCOrORCode(Epc, OrCode);
        }
        //private void SetTrunApply(TrunApplyDetailModel model)
        //{
        //    if (model.ApplyID.HasValue)
        //    {
        //        model.TrunApply = trunApplyAccess.GetEntityById(model.ApplyID.Value);
        //    }
        //}
    }
}
