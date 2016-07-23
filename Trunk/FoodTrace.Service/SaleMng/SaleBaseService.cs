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
    /// 销售管理
    /// </summary>
    public class SaleBaseService : BaseService, ISaleBaseService
    {
        private ISaleBaseAccess saleBaseAccess;

        public SaleBaseService()
        {
            saleBaseAccess = BaseAccess.CreateAccess<ISaleBaseAccess>(AccessMappingKey.SaleBaseAccess.ToString());
        }

        /// <summary>
        /// 删除单条saleBase
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MessageModel DeleteSingleEntity(int id)
        {
            return saleBaseAccess.DeleteSingleEntity(id);
        }

        /// <summary>
        /// 通过ID获取saleBase
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SaleBaseModel GetSaleBaseById(int id)
        {
            return saleBaseAccess.GetEntityById(id);
        }

        /// <summary>
        /// 获取saleBase总条数
        /// </summary>
        /// <returns></returns>
        public int GetSaleBaseCount()
        {
            return saleBaseAccess.GetEntityCount();
        }

        /// <summary>
        /// 获取saleBase总条数
        /// </summary>
        /// <returns></returns>
        public int GetSaleBaseCount(string name)
        {
            int companyID = UserManagement.CurrentCompany.CompanyID;
            return saleBaseAccess.GetEntityCount(companyID, name);
        }

        public List<SaleBaseModel> GetPagerSaleBase(string name, int pageIndex, int pageSize)
        {
            int companyID = UserManagement.CurrentCompany.CompanyID;
            var result = saleBaseAccess.GetPagerSaleBaseByConditions(companyID, name.Trim(), pageIndex, pageSize);
            return result;
        }

        /// <summary>
        /// 插入单条saleBase数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageModel InsertSingleSaleBase(SaleBaseModel model)
        {
            return saleBaseAccess.InsertSingleEntity(model);
        }

        public MessageModel UpdateSingleSaleBase(SaleBaseModel model)
        {
            var data = saleBaseAccess.GetOriEntity(model.SaleID, model.ModifyTime);
            if (data == null) return new MessageModel() { Message = "当前数据不存在或被更新，请刷新后再次操作！", Status = MessageStatus.Error };
            return saleBaseAccess.UpdateSingleEntity(model);
        }

        public SaleBaseModel GetSaleBaseByEPCOrORCode(string Epc, string OrCode)
        {
            SaleBaseAccess access = new SaleBaseAccess();
            return access.GetSaleBaseByEPCOrORCode(Epc, OrCode);
        }
    }
}
