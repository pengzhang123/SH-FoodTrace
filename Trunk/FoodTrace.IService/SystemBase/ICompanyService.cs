using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IService
{
    /// <summary>
    /// 公司管理
    /// </summary>
    public interface ICompanyService
    {
        /// <summary>
        /// 获取Company总条数
        /// </summary>
        /// <returns></returns>
        int GetCompanyCount();

        /// <summary>
        /// 获取Company总条数
        /// </summary>
        /// <param name="name">查询条件：公司名称（模糊查询）</param>
        /// <returns></returns>
        int GetCompanyCount(string name);

        /// <summary>
        /// 获取当前用户所在公司的地块信息（分页）
        /// </summary>
        /// <param name="name">查询条件：公司名称（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        List<CompanyModel> GetPagerCompany(string name, int pageIndex, int pageSize);

        /// <summary>
        /// 通过ID获取Company
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CompanyModel GetCompanyById(int id);

        /// <summary>
        /// 新增单条Company
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel InsertSingleCompany(CompanyModel model);

        /// <summary>
        /// 编辑单条Company
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel UpdateSingleCompany(CompanyModel model);

        /// <summary>
        /// 删除单条Company
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        MessageModel DeleteSingleCompany(int id);

        /// <summary>
        /// 获取企业机构树
        /// </summary>
        /// <returns></returns>
        List<ZtreeModel> GetCompantTree();
    }
}
