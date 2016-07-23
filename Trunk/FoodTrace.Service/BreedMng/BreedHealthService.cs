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
    /// 养殖健康管理
    /// </summary>
    public class BreedHealthService : BaseService, IBreedHealthService
    {
        private IBreedHealthAccess breedHealthAccess;

        public BreedHealthService()
        {
            breedHealthAccess = BaseAccess.CreateAccess<IBreedHealthAccess>(AccessMappingKey.BreedHealthAccess.ToString());
        }

        /// <summary>
        /// 删除单条BreedHealth
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MessageModel DeleteSingleEntity(int id)
        {
            return breedHealthAccess.DeleteSingleEntity(id);
        }

        /// <summary>
        /// 通过ID获取BreedHealth
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BreedHealthModel GetBreedHealthById(int id)
        {
            return breedHealthAccess.GetEntityById(id);
        }

        /// <summary>
        /// 获取BreedHealth总条数
        /// </summary>
        /// <returns></returns>
        public int GetBreedHealthCount()
        {
            return breedHealthAccess.GetEntityCount();
        }

        public int GetBreedHealthCount(string name)
        {
            int companyID = UserManagement.CurrentCompany.CompanyID;
            return breedHealthAccess.GetEntityCount(companyID, name);
        }

        public List<BreedHealthModel> GetPagerBreedHealth(string name, int pageIndex, int pageSize)
        {
            int companyID = UserManagement.CurrentCompany.CompanyID;
            var result = breedHealthAccess.GetPagerBreedHealthByConditions(companyID, name.Trim(), pageIndex, pageSize);
            return result;
        }
        
        /// <summary>
        /// 插入单条BreedHealth数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageModel InsertSingleBreedHealth(BreedHealthModel model)
        {
            return breedHealthAccess.InsertSingleEntity(model);
        }

        /// <summary>
        /// 编辑单条BreedHealth
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageModel UpdateSingleBreedHealth(BreedHealthModel model)
        {
            var data = breedHealthAccess.GetOriEntity(model.HealthID, model.ModifyTime);
            if (data == null) return new MessageModel() { Message = "当前数据不存在或被更新，请刷新后再次操作！", Status = MessageStatus.Error };
            return breedHealthAccess.UpdateSingleEntity(model);
        }
    }
}
