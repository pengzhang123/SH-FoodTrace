using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IService
{
    public interface ICodeMaxService
    {
        /// <summary>
        /// 获取CodeMax总条数
        /// </summary>
        /// <returns></returns>
        int GetCodeMaxCount();
        /// <summary>
        /// 根据对象编码取得对应的最大的ID
        /// </summary>
        /// <param name="objectCode"></param>
        /// <returns></returns>
        string GetMaxCode(string objectCode);
        /// <summary>
        /// 获取CodeMax总条数
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        int GetCodeMaxCount(string name);

        /// <summary>
        /// 获取最大编号信息（分页）
        /// </summary>
        /// <param name="name">查询条件：最大编号（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        List<CodeMaxModel> GetPagerCodeMax(string name, int pageIndex, int pageSize);

        /// <summary>
        /// 通过ID获取CodeMax
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CodeMaxModel GetCodeMaxById(int id);

        /// <summary>
        /// 新增单条CodeMax
        /// </summary>
        /// <param name="model">最大编号实体</param>
        /// <returns></returns>
        MessageModel InsertSingleCodeMax(CodeMaxModel model);

        /// <summary>
        /// 编辑单条CodeMax
        /// </summary>
        /// <param name="model">最大编号实体</param>
        /// <returns></returns>
        MessageModel UpdateSingleCodeMax(CodeMaxModel model);

        /// <summary>
        /// 删除单条CodeMax
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        MessageModel DeleteSingleCodeMax(int id);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        MessageModel DeleteByIds(string ids);
    }
}
