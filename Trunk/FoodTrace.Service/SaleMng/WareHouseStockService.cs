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
    /// 库存管理
    /// </summary>
    public class WareHouseStockService : BaseService, IWareHouseStockService
    {
        private IWareHouseStockAccess wareHouseStockAccess;

        public WareHouseStockService()
        {
            wareHouseStockAccess = BaseAccess.CreateAccess<IWareHouseStockAccess>(AccessMappingKey.WareHouseStockAccess.ToString());
        }

        /// <summary>
        /// 删除单条wareHouseStock
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MessageModel DeleteSingleEntity(int id)
        {
            return wareHouseStockAccess.DeleteSingleEntity(id);
        }

        /// <summary>
        /// 通过ID获取wareHouseStock
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public WareHouseStockModel GetWareHouseStockById(int id)
        {
            return wareHouseStockAccess.GetEntityById(id);
        }

        /// <summary>
        /// 获取wareHouseStock总条数
        /// </summary>
        /// <returns></returns>
        public int GetWareHouseStockCount()
        {
            return wareHouseStockAccess.GetEntityCount();
        }

        /// <summary>
        /// 获取wareHouseStock总条数
        /// </summary>
        /// <returns></returns>
        public int GetWareHouseStockCount(string name)
        {
            int companyID = UserManagement.CurrentCompany.CompanyID;
            return wareHouseStockAccess.GetEntityCount(companyID, name);
        }

        public List<WareHouseStockModel> GetPagerWareHouseStock(string name, int pageIndex, int pageSize)
        {
            int companyID = UserManagement.CurrentCompany.CompanyID;
            var result = wareHouseStockAccess.GetPagerWareHouseStockByConditions(companyID, name.Trim(), pageIndex, pageSize);
            return result;
        }

        /// <summary>
        /// 插入单条wareHouseStock数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageModel InsertSingleWareHouseStock(WareHouseStockModel model)
        {
            return wareHouseStockAccess.InsertSingleEntity(model);
        }

        public MessageModel UpdateSingleWareHouseStock(WareHouseStockModel model)
        {
            var data = wareHouseStockAccess.GetOriEntity(model.StockID, model.ModifyTime);
            if (data == null) return new MessageModel() { Message = "当前数据不存在或被更新，请刷新后再次操作！", Status = MessageStatus.Error };
            return wareHouseStockAccess.UpdateSingleEntity(model);
        }
    }
}
