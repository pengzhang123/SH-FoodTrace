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
    public class TrunApplyService : BaseService, ITrunApplyService
    {
        private ITrunApplyAccess trunApplyAccess;
        private ICompanyAccess companyAccess;

        public TrunApplyService()
        {
            trunApplyAccess = BaseAccess.CreateAccess<ITrunApplyAccess>(AccessMappingKey.TrunApplyAccess.ToString());
            companyAccess = BaseAccess.CreateAccess<ICompanyAccess>(AccessMappingKey.CompanyAccess.ToString());
        }

        /// <summary>
        /// 获取TrunApply总条数
        /// </summary>
        /// <returns></returns>
        public int GetTrunApplyCount()
        {
            return trunApplyAccess.GetEntityCount();
        }

        /// <summary>
        /// 获取TrunApply总条数
        /// </summary>
        /// <param name="applyNo">查询条件：物流订单号（模糊查询）</param>
        /// <returns></returns>
        public int GetTrunApplyCount(string applyNo)
        {
            int companyID = UserManagement.CurrentUser.CompanyId;
            return trunApplyAccess.GetEntityCount(companyID, applyNo.Trim());
        }

        /// <summary>
        /// 获取当前用户所在公司的冷链物流运输订单信息（分页）
        /// </summary>
        /// <param name="applyNo">查询条件：物流订单号（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        public List<TrunApplyModel> GetPagerTrunApply(string applyNo, int pageIndex, int pageSize)
        {
            int companyID = UserManagement.CurrentUser.CompanyId;
            var result = trunApplyAccess.GetPagerTrunApplyByConditions(companyID, applyNo.Trim(), pageIndex, pageSize);
            //result.ForEach(m => SetCompany(m));
            return result;
        }

        /// <summary>
        /// 通过ID获取TrunApply
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TrunApplyModel GetTrunApplyById(int id)
        {
            return trunApplyAccess.GetEntityById(id);
        }

        /// <summary>
        /// 新增单条TrunApply
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        public MessageModel InsertSingleTrunApply(TrunApplyModel model)
        {
            return trunApplyAccess.InsertSingleEntity(model);
        }

        /// <summary>
        /// 编辑单条TrunApply
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        public MessageModel UpdateSingleTrunApply(TrunApplyModel model)
        {
            return trunApplyAccess.UpdateSingleEntity(model);
        }

        /// <summary>
        /// 删除单条TrunApply
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public MessageModel DeleteSingleTrunApply(int id)
        {
            return trunApplyAccess.DeleteSingleEntity(id);
        }


        //private void SetCompany(TrunApplyModel model)
        //{
        //    if (model.CompanyID.HasValue)
        //    {
        //        model.Company = companyAccess.GetEntityById(model.CompanyID.Value);
        //    }
        //}
    }
}
