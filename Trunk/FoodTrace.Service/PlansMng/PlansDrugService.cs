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
    /// 防疫管理
    /// </summary>
    public class PlansDrugService : BaseService, IPlansDrugService
    {
        private IPlansDrugAccess plansDrugAccess;
        private IPlansBatchAccess plansBatchAccess;

        public PlansDrugService()
        {
            plansDrugAccess = BaseAccess.CreateAccess<IPlansDrugAccess>(AccessMappingKey.PlansDrugAccess.ToString());
            plansBatchAccess = BaseAccess.CreateAccess<IPlansBatchAccess>(AccessMappingKey.PlansBatchAccess.ToString());
        }

        /// <summary>
        /// 获取PlansDrug总条数
        /// </summary>
        /// <returns></returns>
        public int GetPlansDrugCount()
        {
            return plansDrugAccess.GetEntityCount();
        }

        /// <summary>
        /// 获取PlansDrug总条数
        /// </summary>
        /// <param name="name">查询条件：肥料名称（模糊查询）</param>
        /// <returns></returns>
        public int GetPlansDrugCount(string name)
        {
            int companyID = UserManagement.CurrentUser.CompanyId;
            return plansDrugAccess.GetEntityCount(companyID, name.Trim());
        }

        /// <summary>
        /// 获取当前用户所在公司的施肥信息（分页）
        /// </summary>
        /// <param name="name">查询条件：肥料名称（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        public List<PlansDrugModel> GetPagerPlansDrug(string name, int pageIndex, int pageSize)
        {
            int companyID = UserManagement.CurrentUser.CompanyId;
            var result = plansDrugAccess.GetPagerPlansDrugByConditions(companyID, name.Trim(), pageIndex, pageSize);
            //result.ForEach(m => SetPlansBatch(m));
            return result;
        }

        /// <summary>
        /// 通过ID获取PlansDrug
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PlansDrugModel GetPlansDrugById(int id)
        {
            return plansDrugAccess.GetEntityById(id);
        }

        /// <summary>
        /// 新增单条PlansDrug
        /// </summary>
        /// <param name="model">防疫信息实体</param>
        /// <returns></returns>
        public MessageModel InsertSinglePlansDrug(PlansDrugModel model)
        {
            return plansDrugAccess.InsertSingleEntity(model);
        }

        /// <summary>
        /// 编辑单条PlansDrug
        /// </summary>
        /// <param name="model">防疫信息实体</param>
        /// <returns></returns>
        public MessageModel UpdateSinglePlansDrug(PlansDrugModel model)
        {
            //var data = plansDrugAccess.GetOriEntity(model.DrugID, model.ModifyTime);
            //if (data == null) return new MessageModel() { Message = "当前数据不存在或被更新，请刷新后再次操作！", Status = MessageStatus.Error };
            return plansDrugAccess.UpdateSingleEntity(model);
        }

        /// <summary>
        /// 删除单条PlansDrug
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public MessageModel DeleteSinglePlansDrug(int id)
        {
            return plansDrugAccess.DeleteSingleEntity(id);
        }

        //private void SetPlansBatch(PlansDrugModel model)
        //{
        //    if (model.BatchID.HasValue)
        //        model.PlansBatch = plansBatchAccess.GetEntityById(model.BatchID.Value);
        //}

        /// <summary>
        /// 分页数据
        /// </summary>
        /// <param name="comId"></param>
        /// <param name="pIndex"></param>
        /// <param name="pSize"></param>
        /// <returns></returns>
        public GridList<PlantDrugDto> GetPlanDrugList(int pIndex, int pSize)
        {
            int comId = UserManagement.CurrentUser.CompanyId;
            return plansDrugAccess.GetPlanDrugList(comId, pIndex, pSize);
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public MessageModel DeleteByIds(string ids)
        {
            return plansDrugAccess.DeleteByIds(ids);
        }

        /// <summary>
        /// 根据Id获取数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PlantDrugDto GetPlantDrugDtoById(int id)
        {
            return plansDrugAccess.GetPlantDrugDtoById(id);
        }
    }
}
