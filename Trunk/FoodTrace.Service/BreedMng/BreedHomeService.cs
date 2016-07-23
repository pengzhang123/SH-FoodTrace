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
    /// 圈舍管理
    /// </summary>
    public class BreedHomeService : BaseService, IBreedHomeService
    {
        private IBreedHomeAccess breedHomeAccess;

        public BreedHomeService()
        {
            breedHomeAccess = BaseAccess.CreateAccess<IBreedHomeAccess>(AccessMappingKey.BreedHomeAccess.ToString());
        }

        /// <summary>
        /// 删除单条BreedHome
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MessageModel DeleteSingleEntity(int id)
        {
            return breedHomeAccess.DeleteSingleEntity(id);
        }

        /// <summary>
        /// 通过ID获取BreedHome
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BreedHomeModel GetBreedHomeById(int id)
        {
            return breedHomeAccess.GetEntityById(id);
        }

        /// <summary>
        /// 获取BreedHome总条数
        /// </summary>
        /// <returns></returns>
        public int GetBreedHomeCount()
        {
            return breedHomeAccess.GetEntityCount();
        }

        public int GetBreedHomeCount(string name)
        {
            int companyID = UserManagement.CurrentCompany.CompanyID;
            return breedHomeAccess.GetEntityCount(companyID, name);
        }

        public List<BreedHomeModel> GetPagerBreedHome(string name, int pageIndex, int pageSize)
        {
            int companyID = UserManagement.CurrentCompany.CompanyID;
            var result = breedHomeAccess.GetPagerBreedHomeByConditions(companyID, name.Trim(), pageIndex, pageSize);
            return result;
        }

        /// <summary>
        /// 插入单条BreedHome数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageModel InsertSingleBreedHome(BreedHomeModel model)
        {
            return breedHomeAccess.InsertSingleEntity(model);
        }

        /// <summary>
        /// 编辑单条BreedHome
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageModel UpdateSingleBreedHome(BreedHomeModel model)
        {
            var data = breedHomeAccess.GetOriEntity(model.HomeID, model.ModifyTime);
            if (data == null) return new MessageModel() { Message = "当前数据不存在或被更新，请刷新后再次操作！", Status = MessageStatus.Error };
            return breedHomeAccess.UpdateSingleEntity(model);
        }
    }
}
