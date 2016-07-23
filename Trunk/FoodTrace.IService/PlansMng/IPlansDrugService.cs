using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IService
{
    /// <summary>
    /// 防疫管理
    /// </summary>
    public interface IPlansDrugService
    {
        /// <summary>
        /// 获取PlansDrug总条数
        /// </summary>
        /// <returns></returns>
        int GetPlansDrugCount();

        /// <summary>
        /// 获取PlansDrug总条数
        /// </summary>
        /// <param name="name">查询条件：肥料名称（模糊查询）</param>
        /// <returns></returns>
        int GetPlansDrugCount(string name);

        /// <summary>
        /// 获取当前用户所在公司的施肥信息（分页）
        /// </summary>
        /// <param name="name">查询条件：肥料名称（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        List<PlansDrugModel> GetPagerPlansDrug(string name, int pageIndex, int pageSize);

        /// <summary>
        /// 通过ID获取PlansDrug
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        PlansDrugModel GetPlansDrugById(int id);

        /// <summary>
        /// 新增单条PlansDrug
        /// </summary>
        /// <param name="model">防疫信息实体</param>
        /// <returns></returns>
        MessageModel InsertSinglePlansDrug(PlansDrugModel model);

        /// <summary>
        /// 编辑单条PlansDrug
        /// </summary>
        /// <param name="model">防疫信息实体</param>
        /// <returns></returns>
        MessageModel UpdateSinglePlansDrug(PlansDrugModel model);

        /// <summary>
        /// 删除单条PlansDrug
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        MessageModel DeleteSinglePlansDrug(int id);
    }
}
