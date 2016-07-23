using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IService
{
    /// <summary>
    /// 加工厂加工产品信息管理
    /// </summary>
    public interface IProcessProductService
    {
        /// <summary>
        /// 获取ProcessProduct总条数
        /// </summary>
        /// <returns></returns>
        int GetProcessProductCount();

        /// <summary>
        /// 获取ProcessProduct总条数
        /// </summary>
        /// <param name="code">查询条件：待加工溯源码（模糊查询）</param>
        /// <returns></returns>
        int GetProcessProductCount(string code);

        /// <summary>
        /// 获取当前用户所在公司的加工产品信息（分页）
        /// </summary>
        /// <param name="code">查询条件：待加工溯源码（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        List<ProcessProductModel> GetPagerProcessProduct(string code, int pageIndex, int pageSize);

        /// <summary>
        /// 通过ID获取ProcessProduct
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ProcessProductModel GetProcessProductById(int id);

        /// <summary>
        /// 新增单条ProcessProduct
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel InsertSingleProcessProduct(ProcessProductModel model);

        /// <summary>
        /// 编辑单条ProcessProduct
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel UpdateSingleProcessProduct(ProcessProductModel model);

        /// <summary>
        /// 删除单条ProcessProduct
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        MessageModel DeleteSingleProcessProduct(int id);
        ProcessProductModel GetProcessProductByEPCOrORCode(string Epc, string OrCode);
    }
}
