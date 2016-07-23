using FoodTrace.Common.Libraries;
using FoodTrace.DBAccess;
using FoodTrace.IDBAccess;
using FoodTrace.IService;
using FoodTrace.Model;
using System.Collections.Generic;
using System;

namespace FoodTrace.Service
{
    /// <summary>
    /// 仓库基本信息管理
    /// </summary>
    public class WareHouseBaseService : BaseService, IWareHouseBaseService
    {
        private IWareHouseBaseAccess wareHouseBaseAccess;

        public WareHouseBaseService()
        {
            wareHouseBaseAccess = BaseAccess.CreateAccess<IWareHouseBaseAccess>(AccessMappingKey.WareHouseBaseAccess.ToString());
        }

        /// <summary>
        /// 删除单条wareHouseBase
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MessageModel DeleteSingleEntity(int id)
        {
            return wareHouseBaseAccess.DeleteSingleEntity(id);
        }

        /// <summary>
        /// 通过ID获取wareHouseBase
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public WareHouseBaseModel GetWareHouseBaseById(int id)
        {
            return wareHouseBaseAccess.GetEntityById(id);
        }

        /// <summary>
        /// 获取wareHouseBase总条数
        /// </summary>
        /// <returns></returns>
        public int GetWareHouseBaseCount()
        {
            return wareHouseBaseAccess.GetEntityCount();
        }

        /// <summary>
        /// 获取wareHouseBase总条数
        /// </summary>
        /// <returns></returns>
        public int GetWareHouseBaseCount(string name)
        {
            int companyID = UserManagement.CurrentCompany.CompanyID;
            return wareHouseBaseAccess.GetEntityCount(companyID, name);
        }

        public List<WareHouseBaseModel> GetPagerWareHouseBase(string name, int pageIndex, int pageSize)
        {
            int companyID = UserManagement.CurrentCompany.CompanyID;
            var result = wareHouseBaseAccess.GetPagerWareHouseBaseByConditions(companyID, name.Trim(), pageIndex, pageSize);
            return result;
        }

        /// <summary>
        /// 插入单条wareHouseBase数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageModel InsertSingleWareHouseBase(WareHouseBaseModel model)
        {
            return wareHouseBaseAccess.InsertSingleEntity(model);
        }

        public MessageModel UpdateSingleWareHouseBase(WareHouseBaseModel model)
        {
            var data = wareHouseBaseAccess.GetOriEntity(model.WareHouseID, model.ModifyTime);
            if (data == null) return new MessageModel() { Message = "当前数据不存在或被更新，请刷新后再次操作！", Status = MessageStatus.Error };
            return wareHouseBaseAccess.UpdateSingleEntity(model);
        }
    }
}
