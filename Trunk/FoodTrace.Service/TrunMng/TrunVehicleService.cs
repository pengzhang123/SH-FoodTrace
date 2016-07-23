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

namespace FoodTrace.Service.TrunMng
{
    public class TrunVehicleService : BaseService, ITrunVehicleService
    {
        private ITrunVehicleAccess trunVehicleAccess;
        private ICompanyAccess companyAccess;

        public TrunVehicleService()
        {
            trunVehicleAccess = BaseAccess.CreateAccess<ITrunVehicleAccess>(AccessMappingKey.TrunVehicleAccess.ToString());
            companyAccess = BaseAccess.CreateAccess<ICompanyAccess>(AccessMappingKey.CompanyAccess.ToString());
        }

        /// <summary>
        /// 获取TrunVehicle总条数
        /// </summary>
        /// <returns></returns>
        public int GetTrunVehicleCount()
        {
            return trunVehicleAccess.GetEntityCount();
        }

        /// <summary>
        /// 获取TrunVehicle总条数
        /// </summary>
        /// <param name="carNo">查询条件：车牌号（模糊查询）</param>
        /// <returns></returns>
        public int GetTrunVehicleCount(string carNo)
        {
            int companyID = UserManagement.CurrentCompany.CompanyID;
            return trunVehicleAccess.GetEntityCount(companyID, carNo.Trim());
        }

        /// <summary>
        /// 获取当前用户所在公司的冷链物流车辆信息（分页）
        /// </summary>
        /// <param name="carNo">查询条件：车牌号（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        public List<TrunVehicleModel> GetPagerTrunVehicle(string carNo, int pageIndex, int pageSize)
        {
            int companyID = UserManagement.CurrentCompany.CompanyID;
            var result = trunVehicleAccess.GetPagerTrunVehicleByConditions(companyID, carNo.Trim(), pageIndex, pageSize);
            //result.ForEach(m => SetCompany(m));
            return result;
        }

        /// <summary>
        /// 通过ID获取TrunVehicle
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TrunVehicleModel GetTrunVehicleById(int id)
        {
            return trunVehicleAccess.GetEntityById(id);
        }

        /// <summary>
        /// 新增单条TrunVehicle
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        public MessageModel InsertSingleTrunVehicle(TrunVehicleModel model)
        {
            return trunVehicleAccess.InsertSingleEntity(model);
        }

        /// <summary>
        /// 编辑单条TrunVehicle
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        public MessageModel UpdateSingleTrunVehicle(TrunVehicleModel model)
        {
            return trunVehicleAccess.UpdateSingleEntity(model);
        }

        /// <summary>
        /// 删除单条TrunVehicle
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public MessageModel DeleteSingleTrunVehicle(int id)
        {
            return trunVehicleAccess.DeleteSingleEntity(id);
        }


        //private void SetCompany(TrunVehicleModel model)
        //{
        //    if (model.CompanyID.HasValue)
        //    {
        //        model.Company = companyAccess.GetEntityById(model.CompanyID.Value);
        //    }
        //}
    }
}
