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
using FoodTrace.Model.DtoModel;

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
            int companyID = UserManagement.CurrentUser.CompanyId;
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
            int companyID = UserManagement.CurrentUser.CompanyId;
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

        /// <summary>
        /// 根据epc获取orcode获取产品基本信息数据
        /// </summary>
        /// <param name="epc"></param>
        /// <param name="orCode"></param>
        /// <returns></returns>
        public ProductInfoDto GetProductByEpcOrCode(string epc, string orCode)
        {

            return processProductAccess.GetProductByEpcOrCode(epc, orCode);
        
        }

        /// <summary>
        /// 肉类,植物，溯源
        /// </summary>
        /// <param name="epc"></param>
        /// <param name="orCode"></param>
        /// <returns></returns>
        public List<ProductTraceDto> GetProductTrace(string epc, string orCode)
        {
            return processProductAccess.GetProductTrace(epc, orCode);
        }

        /// <summary>
        /// 食品溯源具体数据详情
        /// </summary>
        /// <param name="code"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public string GetProductTraceDetailById(string epc,string orCode,int code, int type)
        {
            var result = string.Empty;

            result = processProductAccess.GetProductTraceDetail(epc, orCode, code, type);

            return result;
        }
    }
}
