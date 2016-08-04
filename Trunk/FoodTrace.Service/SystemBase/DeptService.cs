using System.Data.OleDb;
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
    /// 部门管理
    /// </summary>
    public class DeptService : BaseService, IDeptService
    {
        private IDeptAccess deptAccess;
        private ICompanyAccess companyAccess;
        public DeptService()
        {
            deptAccess = BaseAccess.CreateAccess<IDeptAccess>(AccessMappingKey.DeptAccess.ToString());
            companyAccess = BaseAccess.CreateAccess<ICompanyAccess>(AccessMappingKey.CompanyAccess.ToString());
        }

        /// <summary>
        /// 获取Dept总条数
        /// </summary>
        /// <returns></returns>
        public int GetDeptCount()
        {
            return deptAccess.GetEntityCount();
        }

        /// <summary>
        /// 获取Dept总条数
        /// </summary>
        /// <param name="name">查询条件：部门名称（模糊查询）</param>
        /// <returns></returns>
        public int GetDeptCount(string name)
        {
            int companyID = UserManagement.CurrentUser.CompanyId;
            return deptAccess.GetEntityCount(companyID, name.Trim());
        }

        /// <summary>
        /// 获取当前用户所在公司的部门信息（分页）
        /// </summary>
        /// <param name="name">查询条件：部门名称（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        public List<DeptModel> GetPagerDept(string name, int pageIndex, int pageSize,int? companyID=null)
        {
            //if (companyID == null)
            //{
            //    companyID= UserManagement.CurrentUser.CompanyId;
            //}
            //int companyID = UserManagement.CurrentUser.CompanyId;
            var result = deptAccess.GetPagerDeptByConditions(name.Trim(), pageIndex, pageSize,companyID);
            //result.ForEach(m => SetCompany(m));
            return result;
        }


        /// <summary>
        /// 通过ID获取Dept
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DeptModel GetDeptById(int id)
        {
            return deptAccess.GetEntityById(id);
        }

        /// <summary>
        /// 新增单条Dept
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        public MessageModel InsertSingleDept(DeptModel model)
        {
            return deptAccess.InsertSingleEntity(model);
        }

        /// <summary>
        /// 编辑单条Dept
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        public MessageModel UpdateSingleDept(DeptModel model)
        {
            return deptAccess.UpdateSingleEntity(model);
        }

        /// <summary>
        /// 删除单条Dept
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public MessageModel DeleteSingleDept(int id)
        {
            return deptAccess.DeleteSingleEntity(id);
        }

        //private void SetCompany(DeptModel dept)
        //{
        //    if (dept.CompanyID.HasValue)
        //        dept.Company = companyAccess.GetEntityById(dept.CompanyID.Value);
        //}

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public MessageModel DeleteDepts(string ids)
        {
            return deptAccess.DeleteDepts(ids);
        }
        
    }
}
