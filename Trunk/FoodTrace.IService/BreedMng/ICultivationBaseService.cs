using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IService
{
    /// <summary>
    /// 养殖生物管理
    /// </summary>
    public interface ICultivationBaseService
    {
        /// <summary>
        /// 获取CultivationBase总条数
        /// </summary>
        /// <returns></returns>
        int GetCultivationBaseCount();

        /// <summary>
        /// 获取CultivationBase总条数
        /// </summary>
        /// <returns></returns>
        int GetCultivationBaseCount(string name);

        /// <summary>
        /// 获取当前用户所在公司的养殖生物信息（分页）
        /// </summary>
        /// <param name="name">查询条件：地块名称（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        List<CultivationBaseModel> GetPagerCultivationBase(string name, int pageIndex, int pageSize);

        /// <summary>
        /// 通过ID获取CultivationBase
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CultivationBaseModel GetCultivationBaseById(int id);

        /// <summary>
        /// 新增单条CultivationBase
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel InsertSingleCultivationBase(CultivationBaseModel model);

        /// <summary>
        /// 编辑单条CultivationBase
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel UpdateSingleCultivationBase(CultivationBaseModel model);

        /// <summary>
        /// 删除单条CultivationBase
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        MessageModel DeleteSingleEntity(int id);
        CultivationBaseModel GetCultivationInfoByEPCOrORCode(string Epc, string OrCode);
    }
}

