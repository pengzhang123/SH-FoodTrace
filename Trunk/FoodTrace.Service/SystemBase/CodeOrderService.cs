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
    public class CodeOrderService : BaseService, ICodeOrderService
    {
        private ICodeOrderAccess codeOrderAccess;

        public CodeOrderService()
        {
            codeOrderAccess = BaseAccess.CreateAccess<ICodeOrderAccess>(AccessMappingKey.CodeOrderAccess.ToString());
        }

        /// <summary>
        /// 获取CodeOrder总条数
        /// </summary>
        /// <returns></returns>
        public int GetCodeOrderCount()
        {
            return codeOrderAccess.GetEntityCount();
        }

        /// <summary>
        /// 获取CodeOrder总条数
        /// </summary>
        /// <param name="name">查询条件：单据规则（模糊查询）</param>
        /// <returns></returns>
        public int GetCodeOrderCount(string name)
        {
            return codeOrderAccess.GetEntityCount(name.Trim());
        }

        /// <summary>
        /// 获取区域信息（分页）
        /// </summary>
        /// <param name="name">查询条件：单据规则（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        public List<CodeOrderModel> GetPagerCodeOrder(string name, int pageIndex, int pageSize)
        {
            return codeOrderAccess.GetPagerCodeOrderByConditions(name.Trim(), pageIndex, pageSize);
        }

        /// <summary>
        /// 通过ID获取CodeOrder
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CodeOrderModel GetCodeOrderById(int id)
        {
            return codeOrderAccess.GetEntityById(id);
        }

        /// <summary>
        /// 新增单条CodeOrder
        /// </summary>
        /// <param name="model">单据规则信息实体</param>
        /// <returns></returns>
        public MessageModel InsertSingleCodeOrder(CodeOrderModel model)
        {
            return codeOrderAccess.InsertSingleEntity(model);
        }

        /// <summary>
        /// 编辑单条CodeOrder
        /// </summary>
        /// <param name="model">单据规则信息实体</param>
        /// <returns></returns>
        public MessageModel UpdateSingleCodeOrder(CodeOrderModel model)
        {
            return codeOrderAccess.UpdateSingleEntity(model);
        }

        /// <summary>
        /// 删除单条CodeOrder
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public MessageModel DeleteSingleCodeOrder(int id)
        {
            return codeOrderAccess.DeleteSingleEntity(id);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public MessageModel DeleteByIds(string ids)
        {
            return codeOrderAccess.DeleteByIds(ids);
        }
    }
}
