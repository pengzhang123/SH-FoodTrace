using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IService
{
    /// <summary>
    /// 屠宰检疫管理
    /// </summary>
    public interface IKillDrugService
    {
        /// <summary>
        /// 获取KillDrug总条数
        /// </summary>
        /// <returns></returns>
         int GetKillDrugCount();

        /// <summary>
        /// 获取KillDrug总条数
        /// </summary>
        /// <param name="code">查询条件：溯源码（模糊查询）</param>
        /// <returns></returns>
        int GetKillDrugCount(string code);

        /// <summary>
        /// 获取当前用户所在公司的检疫信息（分页）
        /// </summary>
        /// <param name="code">查询条件：溯源码（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        List<KillDrugModel> GetPagerKillDrug(string code, int pageIndex, int pageSize);

        /// <summary>
        /// 通过ID获取KillDrug
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
         KillDrugModel GetKillDrugById(int id);

        /// <summary>
        /// 新增单条KillDrug
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
         MessageModel InsertSingleKillDrug(KillDrugModel model);

        /// <summary>
        /// 编辑单条KillDrug
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
         MessageModel UpdateSingleKillDrug(KillDrugModel model);

        /// <summary>
        /// 删除单条KillDrug
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
         MessageModel DeleteSingleKillDrug(int id);
    }
}
