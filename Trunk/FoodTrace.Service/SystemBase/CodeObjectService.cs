using FoodTrace.DBAccess;
using FoodTrace.IDBAccess;
using FoodTrace.IService;
using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.Service
{
    public class CodeObjectService : BaseService, ICodeObjectService
    {
        private ICodeObjectAccess codeObjectAccess;

        public CodeObjectService()
        {
            codeObjectAccess = BaseAccess.CreateAccess<ICodeObjectAccess>(AccessMappingKey.CodeObjectAccess.ToString());
        }

        /// <summary>
        /// 获取CodeObject总条数
        /// </summary>
        /// <returns></returns>
        public int GetCodeObjectCount()
        {
            return codeObjectAccess.GetEntityCount();
        }

        /// <summary>
        /// 获取CodeObject总条数
        /// </summary>
        /// <param name="name">查询条件：对象规则（模糊查询）</param>
        /// <returns></returns>
        public int GetCodeObjectCount(string name)
        {
            return codeObjectAccess.GetEntityCount(name.Trim());
        }

        /// <summary>
        /// 获取区域信息（分页）
        /// </summary>
        /// <param name="name">查询条件：对象规则（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        public List<CodeObjectModel> GetPagerCodeObject(string name, int pageIndex, int pageSize)
        {
            return codeObjectAccess.GetPagerCodeObjectByConditions(name.Trim(), pageIndex, pageSize);
        }

        /// <summary>
        /// 通过ID获取CodeObject
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CodeObjectModel GetCodeObjectById(int id)
        {
            return codeObjectAccess.GetEntityById(id);
        }

        /// <summary>
        /// 新增单条CodeObject
        /// </summary>
        /// <param name="model">对象规则信息实体</param>
        /// <returns></returns>
        public MessageModel InsertSingleCodeObject(CodeObjectModel model)
        {
            return codeObjectAccess.InsertSingleEntity(model);
        }

        /// <summary>
        /// 编辑单条CodeObject
        /// </summary>
        /// <param name="model">对象规则信息实体</param>
        /// <returns></returns>
        public MessageModel UpdateSingleCodeObject(CodeObjectModel model)
        {
            return codeObjectAccess.UpdateSingleEntity(model);
        }

        /// <summary>
        /// 删除单条CodeObject
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public MessageModel DeleteSingleCodeObject(int id)
        {
            return codeObjectAccess.DeleteSingleEntity(id);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public MessageModel DeleteByIds(string ids)
        {
            return codeObjectAccess.DeleteCodeObjectByIds(ids);
        }
    }
}