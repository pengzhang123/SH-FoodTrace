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
using FoodTrace.Model.BaseDto;
using FoodTrace.Model.DtoModel;

namespace FoodTrace.Service
{
    /// <summary>
    /// 屠宰检疫管理
    /// </summary>
    public class KillDrugService : BaseService, IKillDrugService
    {
        private IKillDrugAccess killDrugAccess;
        private IKillCullAccess killCullAccess;

        public KillDrugService()
        {
            killDrugAccess = BaseAccess.CreateAccess<IKillDrugAccess>(AccessMappingKey.KillDrugAccess.ToString());
            killCullAccess = BaseAccess.CreateAccess<IKillCullAccess>(AccessMappingKey.KillCullAccess.ToString());
        }

        /// <summary>
        /// 获取KillDrug总条数
        /// </summary>
        /// <returns></returns>
        public int GetKillDrugCount()
        {
            return killDrugAccess.GetEntityCount();
        }

        /// <summary>
        /// 获取KillDrug总条数
        /// </summary>
        /// <param name="code">查询条件：溯源码（模糊查询）</param>
        /// <returns></returns>
        public int GetKillDrugCount(string code)
        {
            int companyID = UserManagement.CurrentUser.CompanyId;
            return killDrugAccess.GetEntityCount(companyID, code.Trim());
        }

        /// <summary>
        /// 获取当前用户所在公司的检疫信息（分页）
        /// </summary>
        /// <param name="code">查询条件：溯源码（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        public List<KillDrugModel> GetPagerKillDrug(string code, int pageIndex, int pageSize)
        {
            int companyID = UserManagement.CurrentUser.CompanyId;
            var result = killDrugAccess.GetPagerKillDrugByConditions(companyID, code.Trim(), pageIndex, pageSize);
            //result.ForEach(m => SetKillCull(m));
            return result;
        }

        /// <summary>
        /// 通过ID获取KillDrug
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public KillDrugModel GetKillDrugById(int id)
        {
            return killDrugAccess.GetEntityById(id);
        }

        /// <summary>
        /// 新增单条KillDrug
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        public MessageModel InsertSingleKillDrug(KillDrugModel model)
        {
            return killDrugAccess.InsertSingleEntity(model);
        }

        /// <summary>
        /// 编辑单条KillDrug
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        public MessageModel UpdateSingleKillDrug(KillDrugModel model)
        {
            return killDrugAccess.UpdateSingleEntity(model);
        }

        /// <summary>
        /// 删除单条KillDrug
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public MessageModel DeleteSingleKillDrug(int id)
        {
            return killDrugAccess.DeleteSingleEntity(id);
        }


        //private void SetKillCull(KillDrugModel model)
        //{
        //    if (model.KillCullID.HasValue)
        //        model.KillCull = killCullAccess.GetEntityById(model.KillCullID.Value);
        //}

        /// <summary>
        /// 分页数据
        /// </summary>
        /// <param name="comid"></param>
        /// <param name="pIndex"></param>
        /// <param name="pSize"></param>
        /// <returns></returns>
        public GridList<KillDrugDto> GetKillDrugListPaging(int pIndex, int pSize)
        {
            int comid = UserManagement.CurrentUser.CompanyId;
            return killDrugAccess.GetKillDrugListPaging(comid, pIndex, pSize);
        }


        /// <summary>
        /// 根据id获取数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public KillDrugDto GetKillDrugDtoById(int id)
        {
            return killDrugAccess.GetKillDrugDtoById(id);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public MessageModel DeleteByIds(string ids)
        {
            return killDrugAccess.DeleteByIds(ids);
        }
    }
}
