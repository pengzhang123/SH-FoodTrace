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
    public class CodeMaxService : BaseService, ICodeMaxService
    {
        private ICodeMaxAccess codeMaxAccess;

        public CodeMaxService()
        {
            codeMaxAccess = BaseAccess.CreateAccess<ICodeMaxAccess>(AccessMappingKey.CodeMaxAccess.ToString());
        }

        /// <summary>
        /// 获取CodeMax总条数
        /// </summary>
        /// <returns></returns>
        public int GetCodeMaxCount()
        {
            return codeMaxAccess.GetEntityCount();
        }

        /// <summary>
        /// 获取CodeMax总条数
        /// </summary>
        /// <param name="name">查询条件：最大编号（模糊查询）</param>
        /// <returns></returns>
        public int GetCodeMaxCount(string name)
        {
            return codeMaxAccess.GetEntityCount(name.Trim());
        }

        /// <summary>
        /// 获取区域信息（分页）
        /// </summary>
        /// <param name="name">查询条件：最大编号（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        public List<CodeMaxModel> GetPagerCodeMax(string name, int pageIndex, int pageSize)
        {
            return codeMaxAccess.GetPagerCodeMaxByConditions(name.Trim(), pageIndex, pageSize);
        }

        /// <summary>
        /// 通过ID获取CodeMax
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CodeMaxModel GetCodeMaxById(int id)
        {
            return codeMaxAccess.GetEntityById(id);
        }

        /// <summary>
        /// 新增单条CodeMax
        /// </summary>
        /// <param name="model">最大编号信息实体</param>
        /// <returns></returns>
        public MessageModel InsertSingleCodeMax(CodeMaxModel model)
        {
            return codeMaxAccess.InsertSingleEntity(model);
        }

        /// <summary>
        /// 编辑单条CodeMax
        /// </summary>
        /// <param name="model">最大编号信息实体</param>
        /// <returns></returns>
        public MessageModel UpdateSingleCodeMax(CodeMaxModel model)
        {
            return codeMaxAccess.UpdateSingleEntity(model);
        }

        /// <summary>
        /// 删除单条CodeMax
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public MessageModel DeleteSingleCodeMax(int id)
        {
            return codeMaxAccess.DeleteSingleEntity(id);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public MessageModel DeleteByIds(string ids)
        {
            return codeMaxAccess.DeleteCodeMaxByIds(ids);
        }


        public string GetMaxCode(string objectCode)
        {
            string result = codeMaxAccess.GetMaxCode(objectCode);
            return result;
        }
    }
}