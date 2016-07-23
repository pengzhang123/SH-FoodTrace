using FoodTrace.Common.Libraries;
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
    /// <summary>
    /// 加工厂加工产品信息管理
    /// </summary>
    public class ProcessProductService : BaseService, IProcessProductService
    {
        private IProcessProductAccess processProductAccess;

        public ProcessProductService()
        {
            processProductAccess = BaseAccess.CreateAccess<IProcessProductAccess>(AccessMappingKey.ProcessProductAccess.ToString());
        }

        /// <summary>
        /// 获取ProcessProduct总条数
        /// </summary>
        /// <returns></returns>
        public int GetProcessProductCount()
        {
            return processProductAccess.GetEntityCount();
        }

        /// <summary>
        /// 获取ProcessProduct总条数
        /// </summary>
        /// <param name="code">查询条件：待加工溯源码（模糊查询）</param>
        /// <returns></returns>
        public int GetProcessProductCount(string code)
        {
            int companyID = UserManagement.CurrentCompany.CompanyID;
            return processProductAccess.GetEntityCount(companyID, code.Trim());
        }

        /// <summary>
        /// 获取当前用户所在公司的加工产品信息（分页）
        /// </summary>
        /// <param name="code">查询条件：待加工溯源码（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        public List<ProcessProductModel> GetPagerProcessProduct(string code, int pageIndex, int pageSize)
        {
            int companyID = UserManagement.CurrentCompany.CompanyID;
            var result = processProductAccess.GetPagerProcessProductByConditions(companyID, code.Trim(), pageIndex, pageSize);
            return result;
        }

        /// <summary>
        /// 通过ID获取ProcessProduct
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProcessProductModel GetProcessProductById(int id)
        {
            return processProductAccess.GetEntityById(id);
        }

        /// <summary>
        /// 新增单条ProcessProduct
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        public MessageModel InsertSingleProcessProduct(ProcessProductModel model)
        {
            return processProductAccess.InsertSingleEntity(model);
        }

        /// <summary>
        /// 编辑单条ProcessProduct
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        public MessageModel UpdateSingleProcessProduct(ProcessProductModel model)
        {
            return processProductAccess.UpdateSingleEntity(model);
        }

        /// <summary>
        /// 删除单条ProcessProduct
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public MessageModel DeleteSingleProcessProduct(int id)
        {
            return processProductAccess.DeleteSingleEntity(id);
        }
        public ProcessProductModel GetProcessProductByEPCOrORCode(string Epc, string OrCode)
        {
            ProcessProductAccess access = new ProcessProductAccess();
            return access.GetProcessProductByEPCOrORCode(Epc, OrCode);
        }
    }
}
