using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IDBAccess
{
    public interface ICodeObjectAccess : IBaseAccess<CodeObjectModel>
    {
        int GetEntityCount(string name);

        List<CodeObjectModel> GetPagerCodeObjectByConditions(string name, int pageIndex, int pageSize);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        MessageModel DeleteCodeObjectByIds(string ids);

        /// <summary>
        /// 生成5位流水号长度的批次号
        /// </summary>
        /// <param name="objCode"></param>
        /// <returns></returns>
        string GetCodeObjNum(string objCode);
    }
}