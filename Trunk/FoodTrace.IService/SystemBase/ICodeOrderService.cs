using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IService
{
    public interface ICodeOrderService
    {
        /// <summary>
        /// 获取CodeOrder总条数
        /// </summary>
        /// <returns></returns>
        int GetCodeOrderCount();

        /// <summary>
        /// 获取CodeOrder总条数
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        int GetCodeOrderCount(string name);

        /// <summary>
        /// 获取单据规则信息（分页）
        /// </summary>
        /// <param name="name">查询条件：单据规则（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        List<CodeOrderModel> GetPagerCodeOrder(string name, int pageIndex, int pageSize);

        /// <summary>
        /// 通过ID获取CodeOrder
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CodeOrderModel GetCodeOrderById(int id);

        /// <summary>
        /// 新增单条CodeOrder
        /// </summary>
        /// <param name="model">单据规则实体</param>
        /// <returns></returns>
        MessageModel InsertSingleCodeOrder(CodeOrderModel model);

        /// <summary>
        /// 编辑单条CodeOrder
        /// </summary>
        /// <param name="model">最大编号实体</param>
        /// <returns></returns>
        MessageModel UpdateSingleCodeOrder(CodeOrderModel model);

        /// <summary>
        /// 删除单条CodeOrder
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        MessageModel DeleteSingleCodeOrder(int id);
    }
}
