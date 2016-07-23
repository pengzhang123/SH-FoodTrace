using FoodTrace.Common.Libraries;
using FoodTrace.DBAccess;
using FoodTrace.IDBAccess;
using FoodTrace.IService;
using FoodTrace.Model;
using System;
using System.Collections.Generic;

namespace FoodTrace.Service
{
    /// <summary>
    /// 种类管理
    /// </summary>
    public class VarietyBaseService : BaseService, IVarietyBaseService
    {
        private IVarietyBaseAccess varietyBaseAccess;

        public VarietyBaseService()
        {
            varietyBaseAccess = BaseAccess.CreateAccess<IVarietyBaseAccess>(AccessMappingKey.VarietyBaseAccess.ToString());
        }

        /// <summary>
        /// 删除单条VarietyBase
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MessageModel DeleteSingleEntity(int id)
        {
            return varietyBaseAccess.DeleteSingleEntity(id);
        }

        /// <summary>
        /// 通过ID获取VarietyBase
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public VarietyBaseModel GetVarietyBaseById(int id)
        {
            return varietyBaseAccess.GetEntityById(id);
        }

        /// <summary>
        /// 获取VarietyBase总条数
        /// </summary>
        /// <returns></returns>
        public int GetVarietyBaseCount()
        {
            return varietyBaseAccess.GetEntityCount();
        }

        public List<VarietyBaseModel> GetPagerVarietyBase(string name, int pageIndex, int pageSize)
        {
            int companyID = UserManagement.CurrentCompany.CompanyID;
            var result = varietyBaseAccess.GetPagerVarietyBaseByConditions(companyID, name.Trim(), pageIndex, pageSize);
            return result;
        }

        /// <summary>
        /// 插入单条VarietyBase数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageModel InsertSingleVarietyBase(VarietyBaseModel model)
        {
            return varietyBaseAccess.InsertSingleEntity(model);
        }

        /// <summary>
        /// 编辑单条VarietyBase
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageModel UpdateSingleVarietyBase(VarietyBaseModel model)
        {
            var data = varietyBaseAccess.GetOriEntity(model.VarietyID, model.ModifyTime);
            if (data == null) return new MessageModel() { Message = "当前数据不存在或被更新，请刷新后再次操作！", Status = MessageStatus.Error };
            return varietyBaseAccess.UpdateSingleEntity(model);
        }

        public int GetVarietyBaseCount(string name)
        {
            int companyID = UserManagement.CurrentCompany.CompanyID;
            return varietyBaseAccess.GetEntityCount(companyID, name);
        }
    }
}
