using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IService
{
    /// <summary>
    /// 皮影加工对应的工序信息管理
    /// </summary>
    public interface IShadowProcessService
    {
        /// <summary>
        /// 获取ShadowProcess总条数
        /// </summary>
        /// <returns></returns>
        int GetShadowProcessCount();

        /// <summary>
        /// 获取ShadowProcess总条数
        /// </summary>
        /// <param name="code">查询条件：加工批次（模糊查询）</param>
        /// <returns></returns>
        int GetShadowProcessCount(string code);

        /// <summary>
        /// 获取当前用户所在公司的皮影加工对应的工序信息（分页）
        /// </summary>
        /// <param name="code">查询条件：加工批次（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        List<ShadowProcessModel> GetPagerShadowProcess(string code, int pageIndex, int pageSize);

        /// <summary>
        /// 通过ID获取ShadowProcess
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ShadowProcessModel GetShadowProcessById(int id);

        /// <summary>
        /// 新增单条ShadowProcess
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel InsertSingleShadowProcess(ShadowProcessModel model);

        /// <summary>
        /// 编辑单条ShadowProcess
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel UpdateSingleShadowProcess(ShadowProcessModel model);

        /// <summary>
        /// 删除单条ShadowProcess
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        MessageModel DeleteSingleShadowProcess(int id);
    }
}
