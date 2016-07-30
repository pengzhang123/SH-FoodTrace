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
    /// 屠宰明细查询
    /// </summary>
    public class KillBatchDetailService : BaseService, IKillBatchDetailService
    {
        private IKillBatchDetailAccess killBatchDetailAccess;
        private IKillBatchAccess killBatchAccess;
        private ICultivationBaseAccess cultivationBaseAccess;
        private IBreedBaseAccess breedBaseAccess;
        private IBreedAreaAccess breedAreaAccess;
        private IBreedHomeAccess breedHomeAccess;
        public KillBatchDetailService()
        {
            killBatchDetailAccess = BaseAccess.CreateAccess<IKillBatchDetailAccess>(AccessMappingKey.KillBatchDetailAccess.ToString());
            killBatchAccess = BaseAccess.CreateAccess<IKillBatchAccess>(AccessMappingKey.KillBatchAccess.ToString());
            cultivationBaseAccess = BaseAccess.CreateAccess<ICultivationBaseAccess>(AccessMappingKey.CultivationBaseAccess.ToString());
            breedBaseAccess = BaseAccess.CreateAccess<IBreedBaseAccess>(AccessMappingKey.BreedBaseAccess.ToString());
            breedAreaAccess = BaseAccess.CreateAccess<IBreedAreaAccess>(AccessMappingKey.BreedAreaAccess.ToString());
            breedHomeAccess = BaseAccess.CreateAccess<IBreedHomeAccess>(AccessMappingKey.BreedHomeAccess.ToString());
        }

        /// <summary>
        /// 获取KillBatchDetail总条数
        /// </summary>
        /// <returns></returns>
        public int GetKillBatchDetailCount()
        {
            return killBatchDetailAccess.GetEntityCount();
        }

        /// <summary>
        /// 获取KillBatchDetail总条数
        /// </summary>
        /// <param name="code">查询条件：溯源码（模糊查询）</param>
        /// <returns></returns>
        public int GetKillBatchDetailCount(string code)
        {
            int companyID = UserManagement.CurrentUser.CompanyId;
            return killBatchDetailAccess.GetEntityCount(companyID, code.Trim());
        }

        /// <summary>
        /// 获取当前用户所在公司的屠宰详细信息（分页）
        /// </summary>
        /// <param name="code">查询条件：溯源码（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        public List<KillBatchDetailModel> GetPagerKillBatchDetail(string code, int pageIndex, int pageSize)
        {
            int companyID = UserManagement.CurrentUser.CompanyId;
            var result = killBatchDetailAccess.GetPagerKillBatchDetailByConditions(companyID, code.Trim(), pageIndex, pageSize);
            //foreach (var item in result)
            //{
            //    SetKillBatch(item);
            //    SetCultivationBase(item);
            //    SetBreedBase(item);
            //    SetBreedArea(item);
            //    SetBreedHome(item);
            //}
            return result;
        }

        /// <summary>
        /// 通过ID获取KillBatchDetail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public KillBatchDetailModel GetKillBatchDetailById(int id)
        {
            return killBatchDetailAccess.GetEntityById(id);
        }

        /// <summary>
        /// 新增单条KillBatchDetail
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        public MessageModel InsertSingleKillBatchDetail(KillBatchDetailModel model)
        {
            return killBatchDetailAccess.InsertSingleEntity(model);
        }

        /// <summary>
        /// 编辑单条KillBatchDetail
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        public MessageModel UpdateSingleKillBatchDetail(KillBatchDetailModel model)
        {
            return killBatchDetailAccess.UpdateSingleEntity(model);
        }

        /// <summary>
        /// 删除单条KillBatchDetail
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public MessageModel DeleteSingleKillBatchDetail(int id)
        {
            return killBatchDetailAccess.DeleteSingleEntity(id);
        }

        //private void SetKillBatch(KillBatchDetailModel model)
        //{
        //    if (model.KillBatchID.HasValue)
        //        model.KillBatch = killBatchAccess.GetEntityById(model.KillBatchID.Value);
        //}

        //private void SetCultivationBase(KillBatchDetailModel model)
        //{
        //    model.CultivationBase = cultivationBaseAccess.GetEntityById(model.CultivationID);
        //}

        //private void SetBreedBase(KillBatchDetailModel model)
        //{
        //    if (model.BreedID.HasValue)
        //        model.BreedBase = breedBaseAccess.GetEntityById(model.BreedID.Value);
        //}

        //private void SetBreedArea(KillBatchDetailModel model)
        //{
        //    if (model.AreaID.HasValue)
        //        model.BreedArea = breedAreaAccess.GetEntityById(model.AreaID.Value);
        //}

        //private void SetBreedHome(KillBatchDetailModel model)
        //{
        //    if (model.HomeID.HasValue)
        //        model.BreedHome = breedHomeAccess.GetEntityById(model.HomeID.Value);
        //}
    }
}
