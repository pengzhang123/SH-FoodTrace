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
    /// 仓库详细信息管理
    /// </summary>
    public class WareHouseDetailService : BaseService, IWareHouseDetailService
    {
        private IWareHouseDetailAccess wareHouseDetailAccess;

        public WareHouseDetailService()
        {
            wareHouseDetailAccess = BaseAccess.CreateAccess<IWareHouseDetailAccess>(AccessMappingKey.WareHouseDetailAccess.ToString());
        }

        /// <summary>
        /// 删除单条wareHouseBase
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MessageModel DeleteSingleEntity(int id)
        {
            return wareHouseDetailAccess.DeleteSingleEntity(id);
        }

        /// <summary>
        /// 通过ID获取wareHouseBase
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public WareHouseDetailModel GetWareHouseDetailById(int id)
        {
            return wareHouseDetailAccess.GetEntityById(id);
        }

        /// <summary>
        /// 获取wareHouseBase总条数
        /// </summary>
        /// <returns></returns>
        public int GetWareHouseDetailCount()
        {
            return wareHouseDetailAccess.GetEntityCount();
        }

        /// <summary>
        /// 获取wareHouseBase总条数
        /// </summary>
        /// <returns></returns>
        public int GetWareHouseDetailCount(string name)
        {
            int companyID = UserManagement.CurrentUser.CompanyId;
            return wareHouseDetailAccess.GetEntityCount(companyID, name);
        }

        public List<WareHouseDetailModel> GetPagerWareHouseDetail(string name, int pageIndex, int pageSize)
        {
            int companyID = UserManagement.CurrentUser.CompanyId;
            var result = wareHouseDetailAccess.GetPagerWareHouseDetailByConditions(companyID, name.Trim(), pageIndex, pageSize);
            return result;
        }

        /// <summary>
        /// 插入单条wareHouseBase数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageModel InsertSingleWareHouseDetail(WareHouseDetailModel model)
        {
            return wareHouseDetailAccess.InsertSingleEntity(model);
        }

        public MessageModel UpdateSingleWareHouseDetail(WareHouseDetailModel model)
        {
            var data = wareHouseDetailAccess.GetOriEntity(model.DetailID, model.ModifyTime);
            if (data == null) return new MessageModel() { Message = "当前数据不存在或被更新，请刷新后再次操作！", Status = MessageStatus.Error };
            return wareHouseDetailAccess.UpdateSingleEntity(model);
        }
    }
}
