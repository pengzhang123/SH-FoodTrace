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
    /// 屠宰批次管理
    /// </summary>
    public interface IKillCullService
    {
        /// <summary>
        /// 获取KillCull总条数
        /// </summary>
        /// <returns></returns>
        int GetKillCullCount();

        /// <summary>
        /// 获取KillCull总条数
        /// </summary>
        /// <param name="code">养殖溯源码</param>
        /// <returns></returns>
        int GetKillCullCount(string code);

        /// <summary>
        /// 获取当前用户的所在公司的屠宰批次信息（分页）
        /// </summary>
        /// <param name="code">养殖溯源码</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        List<KillCullModel> GetPagerKillCull(string code, int pageIndex, int pageSize);

        /// <summary>
        /// 通过ID获取KillCull
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        KillCullModel GetKillCullById(int id);

        /// <summary>
        /// 新增单条KillCull
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel InsertSingleKillCull(KillCullModel model);

        /// <summary>
        /// 编辑单条KillCull
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel UpdateSingleKillCull(KillCullModel model);

        /// <summary>
        /// 删除单条KillCull
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        MessageModel DeleteSingleKillCull(int id);
        KillCullModel GetKillCullByEPCOrORCode(string Epc, string OrCode);

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="comId"></param>
        /// <param name="pIndex"></param>
        /// <param name="pSize"></param>
        /// <returns></returns>
        GridList<KillCullDto> GetKillCullListPaging(int pIndex, int pSize);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        MessageModel DeleteByIds(string ids);

        /// <summary>
        /// 获取个人信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        KillCullDto GetKillCullDtoById(int id);
    }
}
