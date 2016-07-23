using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IService
{
    /// <summary>
    /// 品种管理
    /// </summary>
    public interface IVarietyBaseService
    {
        /// <summary>
        /// 获取VarietyBase总条数
        /// </summary>
        /// <returns></returns>
        int GetVarietyBaseCount();

        /// <summary>
        /// 获取VarietyBase总条数
        /// </summary>
        /// <returns></returns>
        int GetVarietyBaseCount(string name);

        /// <summary>
        /// 获取当前用户所在公司的品种信息（分页）
        /// </summary>
        /// <param name="name">查询条件：地块名称（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        List<VarietyBaseModel> GetPagerVarietyBase(string name, int pageIndex, int pageSize);

        /// <summary>
        /// 通过ID获取VarietyBase
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        VarietyBaseModel GetVarietyBaseById(int id);

        /// <summary>
        /// 新增单条VarietyBase
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel InsertSingleVarietyBase(VarietyBaseModel model);

        /// <summary>
        /// 编辑单条VarietyBase
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel UpdateSingleVarietyBase(VarietyBaseModel model);

        /// <summary>
        /// 删除单条VarietyBase
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        MessageModel DeleteSingleEntity(int id);
    }
}
