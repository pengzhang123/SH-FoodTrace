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
    /// 养殖生物管理
    /// </summary>
    public class CultivationBaseService : BaseService, ICultivationBaseService
    {
        private ICultivationBaseAccess cultivationBaseAccess;

        public CultivationBaseService()
        {
            cultivationBaseAccess = BaseAccess.CreateAccess<ICultivationBaseAccess>(AccessMappingKey.CultivationBaseAccess.ToString());
        }

        /// <summary>
        /// 删除单条CultivationBase
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MessageModel DeleteSingleEntity(int id)
        {
            return cultivationBaseAccess.DeleteSingleEntity(id);
        }

        /// <summary>
        /// 通过ID获取CultivationBase
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CultivationBaseModel GetCultivationBaseById(int id)
        {
            return cultivationBaseAccess.GetEntityById(id);
        }

        /// <summary>
        /// 获取CultivationBase总条数
        /// </summary>
        /// <returns></returns>
        public int GetCultivationBaseCount()
        {
            return cultivationBaseAccess.GetEntityCount();
        }

        public int GetCultivationBaseCount(string name)
        {
            int companyID = UserManagement.CurrentUser.CompanyId;
            return cultivationBaseAccess.GetEntityCount(companyID, name);
        }

        public List<CultivationBaseModel> GetPagerCultivationBase(string name, int pageIndex, int pageSize)
        {
            int companyID = UserManagement.CurrentUser.CompanyId;
            var result = cultivationBaseAccess.GetPagerCultivationBaseByConditions(companyID, name.Trim(), pageIndex, pageSize);
            return result;
        }

        /// <summary>
        /// 插入单条CultivationBase数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageModel InsertSingleCultivationBase(CultivationBaseModel model)
        {
            return cultivationBaseAccess.InsertSingleEntity(model);
        }

        /// <summary>
        /// 编辑单条CultivationBase
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageModel UpdateSingleCultivationBase(CultivationBaseModel model)
        {
            var data = cultivationBaseAccess.GetOriEntity(model.CultivationID, model.ModifyTime);
            if (data == null) return new MessageModel() { Message = "当前数据不存在或被更新，请刷新后再次操作！", Status = MessageStatus.Error };
            return cultivationBaseAccess.UpdateSingleEntity(model);
        }

        public CultivationBaseModel GetCultivationInfoByEPCOrORCode(string Epc, string OrCode)
        {
            CultivationBaseAccess access = new CultivationBaseAccess();
            return access.GetCultivationInfoByEPCOrORCode(Epc, OrCode);
        }
    }
}
