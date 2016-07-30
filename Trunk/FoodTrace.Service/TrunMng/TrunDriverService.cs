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
    public class TrunDriverService : BaseService, ITrunDriverService
    {
        private ITrunDriverAccess trunDriverAccess;
        private ICompanyAccess companyAccess;

        public TrunDriverService()
        {
            trunDriverAccess = BaseAccess.CreateAccess<ITrunDriverAccess>(AccessMappingKey.TrunDriverAccess.ToString());
            companyAccess = BaseAccess.CreateAccess<ICompanyAccess>(AccessMappingKey.CompanyAccess.ToString());
        }

        /// <summary>
        /// 获取TrunDriver总条数
        /// </summary>
        /// <returns></returns>
        public int GetTrunDriverCount()
        {
            return trunDriverAccess.GetEntityCount();
        }

        /// <summary>
        /// 获取TrunDriver总条数
        /// </summary>
        /// <param name="carNo">查询条件：司机名称（模糊查询）</param>
        /// <returns></returns>
        public int GetTrunDriverCount(string name)
        {
            int companyID = UserManagement.CurrentUser.CompanyId;
            return trunDriverAccess.GetEntityCount(companyID, name.Trim());
        }

        /// <summary>
        /// 获取当前用户所在公司的冷链物流司机信息（分页）
        /// </summary>
        /// <param name="carNo">查询条件：司机名称（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        public List<TrunDriverModel> GetPagerTrunDriver(string name, int pageIndex, int pageSize)
        {
            int companyID = UserManagement.CurrentUser.CompanyId;
            var result = trunDriverAccess.GetPagerTrunDriverByConditions(companyID, name.Trim(), pageIndex, pageSize);
            //result.ForEach(m => SetCompany(m));
            return result;
        }

        /// <summary>
        /// 通过ID获取TrunDriver
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TrunDriverModel GetTrunDriverById(int id)
        {
            return trunDriverAccess.GetEntityById(id);
        }

        /// <summary>
        /// 新增单条TrunDriver
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        public MessageModel InsertSingleTrunDriver(TrunDriverModel model)
        {
            return trunDriverAccess.InsertSingleEntity(model);
        }

        /// <summary>
        /// 编辑单条TrunDriver
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        public MessageModel UpdateSingleTrunDriver(TrunDriverModel model)
        {
            return trunDriverAccess.UpdateSingleEntity(model);
        }

        /// <summary>
        /// 删除单条TrunDriver
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public MessageModel DeleteSingleTrunDriver(int id)
        {
            return trunDriverAccess.DeleteSingleEntity(id);
        }


        //private void SetCompany(TrunDriverModel model)
        //{
        //    if (model.CompanyID.HasValue)
        //    {
        //        model.Company = companyAccess.GetEntityById(model.CompanyID.Value);
        //    }
        //}
    }
}
