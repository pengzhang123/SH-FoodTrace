using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IService
{
    /// <summary>
    /// 成品皮影加工基本信息管理
    /// </summary>
    public interface IShadowBaseService
    {
        /// <summary>
        /// 获取ShadowBase总条数
        /// </summary>
        /// <returns></returns>
        int GetShadowBaseCount();

        /// <summary>
        /// 获取ShadowBase总条数
        /// </summary>
        /// <param name="code">查询条件：皮影溯源码（模糊查询）</param>
        /// <returns></returns>
        int GetShadowBaseCount(string code);

        /// <summary>
        /// 获取当前用户所在公司的成品皮影加工基本信息（分页）
        /// </summary>
        /// <param name="code">查询条件：皮影溯源码（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        List<ShadowBaseModel> GetPagerShadowBase(string code, int pageIndex, int pageSize);

        /// <summary>
        /// 通过ID获取ShadowBase
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ShadowBaseModel GetShadowBaseById(int id);

        /// <summary>
        /// 新增单条ShadowBase
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel InsertSingleShadowBase(ShadowBaseModel model);

        /// <summary>
        /// 编辑单条ShadowBase
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel UpdateSingleShadowBase(ShadowBaseModel model);

        /// <summary>
        /// 删除单条ShadowBase
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        MessageModel DeleteSingleShadowBase(int id);
        ShadowBaseModel GetShawInfoByEPCOrORCode(string Epc, string OrCode);
        ShadowBaseModel GetShawInfoByChipCode(string chipCode);
    }
}
