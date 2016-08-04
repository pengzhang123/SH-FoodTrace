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
    /// 公司管理
    /// </summary>
    public class CompanyService : BaseService, ICompanyService
    {
        private ICompanyAccess companyAccess;

        public CompanyService()
        {
            companyAccess = BaseAccess.CreateAccess<ICompanyAccess>(AccessMappingKey.CompanyAccess.ToString());
        }

        /// <summary>
        /// 获取Company总条数
        /// </summary>
        /// <returns></returns>
        public int GetCompanyCount()
        {
            return companyAccess.GetEntityCount();
        }

        /// <summary>
        /// 获取Company总条数
        /// </summary>
        /// <param name="name">查询条件：公司名称（模糊查询）</param>
        /// <returns></returns>
        public int GetCompanyCount(string name)
        {
            return companyAccess.GetEntityCount(name.Trim());
        }

        /// <summary>
        /// 获取当前用户所在公司的地块信息（分页）
        /// </summary>
        /// <param name="name">查询条件：公司名称（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        public List<CompanyModel> GetPagerCompany(string name, int pageIndex, int pageSize)
        {
            int companyID = UserManagement.CurrentUser.CompanyId;
            return companyAccess.GetPagerCompanyByConditions(name.Trim(), pageIndex, pageSize);
        }

        /// <summary>
        /// 通过ID获取Company
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CompanyModel GetCompanyById(int id)
        {
            return companyAccess.GetEntityById(id);
        }

        /// <summary>
        /// 新增单条Company
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        public MessageModel InsertSingleCompany(CompanyModel model)
        {
            return companyAccess.InsertSingleEntity(model);
        }

        /// <summary>
        /// 编辑单条Company
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        public MessageModel UpdateSingleCompany(CompanyModel model)
        {
            return companyAccess.UpdateSingleEntity(model);
        }

        /// <summary>
        /// 删除单条Company
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public MessageModel DeleteSingleCompany(int id)
        {
            return companyAccess.DeleteSingleEntity(id);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public MessageModel DeleteCompanyByIds(string ids)
        {
            return companyAccess.DeleteCompanyByIds(ids);
        }
        /// <summary>
        /// 获取企业机构树
        /// </summary>
        /// <returns></returns>
        public List<ZtreeModel> GetCompantTree()
        {
            int comId = UserManagement.CurrentUser.CompanyId;
            return companyAccess.GetCompantTree(comId);
        }
    }
}
