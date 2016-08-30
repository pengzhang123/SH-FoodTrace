using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IService
{
    public interface ICodeObjectService
    {
        /// <summary>
        /// 获取CodeObject总条数
        /// </summary>
        /// <returns></returns>
        int GetCodeObjectCount();

        /// <summary>
        /// 获取CodeObject总条数
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        int GetCodeObjectCount(string name);

        /// <summary>
        /// 获取对象规则信息（分页）
        /// </summary>
        /// <param name="name">查询条件：对象规则（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        List<CodeObjectModel> GetPagerCodeObject(string name, int pageIndex, int pageSize);

        /// <summary>
        /// 通过ID获取CodeObject
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CodeObjectModel GetCodeObjectById(int id);

        /// <summary>
        /// 新增单条CodeObject
        /// </summary>
        /// <param name="model">对象规则实体</param>
        /// <returns></returns>
        MessageModel InsertSingleCodeObject(CodeObjectModel model);

        /// <summary>
        /// 编辑单条CodeObject
        /// </summary>
        /// <param name="model">对象规则实体</param>
        /// <returns></returns>
        MessageModel UpdateSingleCodeObject(CodeObjectModel model);

        /// <summary>
        /// 删除单条CodeObject
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        MessageModel DeleteSingleCodeObject(int id);


        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        MessageModel DeleteByIds(string ids);

        /// <summary>
        /// 生成5位流水号长度的批次号
        /// </summary>
        /// <param name="objCode"></param>
        /// <returns></returns>
        string GetCodeObjNum(string objCode);

    }
}
