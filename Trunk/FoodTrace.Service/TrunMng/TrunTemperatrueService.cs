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
    public class TrunTemperatrueService : BaseService, ITrunTemperatrueService
    {
        private ITrunTemperatrueAccess trunTemperatrueAccess;
        private ITrunApplyAccess trunApplyAccess;

        public TrunTemperatrueService()
        {
            trunTemperatrueAccess = BaseAccess.CreateAccess<ITrunTemperatrueAccess>(AccessMappingKey.TrunTemperatrueAccess.ToString());
            trunApplyAccess = BaseAccess.CreateAccess<ITrunApplyAccess>(AccessMappingKey.TrunApplyAccess.ToString());
        }

        /// <summary>
        /// 获取TrunTemperatrue总条数
        /// </summary>
        /// <returns></returns>
        public int GetTrunTemperatrueCount()
        {
            int companyID = UserManagement.CurrentUser.CompanyId;
            return trunTemperatrueAccess.GetEntityCount();
        }

        ///// <summary>
        ///// 获取TrunTemperatrue总条数
        ///// </summary>
        ///// <param name="carNo">查询条件：车牌号（模糊查询）</param>
        ///// <returns></returns>
        //public int GetTrunTemperatrueCount(string carNo)
        //{
        //    int companyID = UserManagement.CurrentUser.CompanyId;
        //    return trunTemperatrueAccess.GetEntityCount(companyID, carNo.Trim());
        //}

        /// <summary>
        /// 获取当前用户所在公司的冷链运输GPS温度采集记录信息（分页）
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        public List<TrunTemperatrueModel> GetPagerTrunTemperatrue(int pageIndex, int pageSize)
        {
            int companyID = UserManagement.CurrentUser.CompanyId;
            var result = trunTemperatrueAccess.GetPagerTrunTemperatrueByConditions(companyID, pageIndex, pageSize);
            //result.ForEach(m => SetTrunApply(m));
            return result;
        }

        /// <summary>
        /// 通过ID获取TrunTemperatrue
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TrunTemperatrueModel GetTrunTemperatrueById(int id)
        {
            return trunTemperatrueAccess.GetEntityById(id);
        }

        /// <summary>
        /// 新增单条TrunTemperatrue
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        public MessageModel InsertSingleTrunTemperatrue(TrunTemperatrueModel model)
        {
            return trunTemperatrueAccess.InsertSingleEntity(model);
        }

        /// <summary>
        /// 编辑单条TrunTemperatrue
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        public MessageModel UpdateSingleTrunTemperatrue(TrunTemperatrueModel model)
        {
            return trunTemperatrueAccess.UpdateSingleEntity(model);
        }

        /// <summary>
        /// 删除单条TrunTemperatrue
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public MessageModel DeleteSingleTrunTemperatrue(int id)
        {
            return trunTemperatrueAccess.DeleteSingleEntity(id);
        }


        //private void SetTrunApply(TrunTemperatrueModel model)
        //{
        //    if (model.ApplyID.HasValue)
        //    {
        //        model.TrunApply = trunApplyAccess.GetEntityById(model.ApplyID.Value);
        //    }
        //}
    }
}
