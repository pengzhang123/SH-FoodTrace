using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTrace.Model.BaseDto;
using FoodTrace.Model.DtoModel;

namespace FoodTrace.IService
{
    /// <summary>
    /// 施肥管理
    /// </summary>
    public interface IPlansFertService
    {
        /// <summary>
        /// 获取PlansFert总条数
        /// </summary>
        /// <returns></returns>
        int GetPlansFertCount();

        /// <summary>
        /// 获取PlansFert总条数
        /// </summary>
        /// <param name="code">查询条件：溯源码（模糊查询）</param>
        /// <returns></returns>
        int GetPlansFertCount(string code);

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="name">查询条件：溯源码（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        List<PlansFertModel> GetPagerPlansFert(string code, int pageIndex, int pageSize);

        /// <summary>
        /// 通过ID获取PlansFert
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        PlansFertModel GetPlansFertById(int id);

        /// <summary>
        /// 新增单条PlansFert
        /// </summary>
        /// <param name="model">施肥信息实体</param>
        /// <returns></returns>
        MessageModel InsertSinglePlansFert(PlansFertModel model);

        /// <summary>
        /// 编辑单条PlansFert
        /// </summary>
        /// <param name="model">施肥信息实体</param>
        /// <returns></returns>
        MessageModel UpdateSinglePlansFert(PlansFertModel model);

        /// <summary>
        /// 删除单条PlansFert
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        MessageModel DeleteSinglePlansFert(int id);

        /// <summary>
        /// 数据分页
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pIndex"></param>
        /// <param name="pSize"></param>
        /// <returns></returns>
       GridList<PlansFertDto> GetPlansFertPagingList(string name, int pIndex, int pSize);

        /// <summary>
        /// 根据id获取数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        PlansFertDto GetFerDtoById(int id);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        MessageModel DeleteByIds(string ids);
    }
}
