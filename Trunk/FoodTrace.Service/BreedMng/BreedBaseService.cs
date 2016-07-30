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
    /// 养殖基础信息管理
    /// </summary>
    public class BreedBaseService : BaseService, IBreedBaseService
    {
        private IBreedBaseAccess breedBaseAccess;
        public BreedBaseService()
        {
            breedBaseAccess = BaseAccess.CreateAccess<IBreedBaseAccess>(AccessMappingKey.BreedBaseAccess.ToString());
        }

        /// <summary>
        /// 删除单条BreedBase
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MessageModel DeleteSingleEntity(int id)
        {
            return breedBaseAccess.DeleteSingleEntity(id);
        }

        /// <summary>
        /// 通过ID获取BreedBase
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BreedBaseModel GetBreedBaseById(int id)
        {
            return breedBaseAccess.GetEntityById(id);
        }

        /// <summary>
        /// 获取BreedBase总条数
        /// </summary>
        /// <returns></returns>
        public int GetBreedBaseCount()
        {
            return breedBaseAccess.GetEntityCount();
        }

        /// <summary>
        /// 获取BreedBase总条数
        /// </summary>
        /// <returns></returns>
        public int GetBreedBaseCount(string name)
        {
            int companyID = UserManagement.CurrentUser.CompanyId;
            return breedBaseAccess.GetEntityCount(companyID,name);
        }

        public List<BreedBaseModel> GetPagerBreedBase(string name, int pageIndex, int pageSize)
        {
            int companyID = UserManagement.CurrentUser.CompanyId;
            var result = breedBaseAccess.GetPagerBreedBaseByConditions(companyID, name.Trim(), pageIndex, pageSize);
            return result;
        }

        /// <summary>
        /// 插入单条BreedBase数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageModel InsertSingleBreedBase(BreedBaseModel model)
        {
            return breedBaseAccess.InsertSingleEntity(model);
        }

        public MessageModel UpdateSingleBreedBase(BreedBaseModel model)
        {
            var data = breedBaseAccess.GetOriEntity(model.BreedID, model.ModifyTime);
            if (data == null) return new MessageModel() { Message = "当前数据不存在或被更新，请刷新后再次操作！", Status = MessageStatus.Error };
            return breedBaseAccess.UpdateSingleEntity(model);
        }
    }
}
