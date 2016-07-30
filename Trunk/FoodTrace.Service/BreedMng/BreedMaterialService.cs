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
    /// 用料管理
    /// </summary>
    public class BreedMaterialService : BaseService, IBreedMaterialService
    {
        private IBreedMaterialAccess breedMaterialAccess;

        public BreedMaterialService()
        {
            breedMaterialAccess = BaseAccess.CreateAccess<IBreedMaterialAccess>(AccessMappingKey.BreedMaterialAccess.ToString());
        }

        /// <summary>
        /// 删除单条BreedMaterial
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MessageModel DeleteSingleEntity(int id)
        {
            return breedMaterialAccess.DeleteSingleEntity(id);
        }

        /// <summary>
        /// 通过ID获取BreedMaterial
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BreedMaterialModel GetBreedMaterialById(int id)
        {
            return breedMaterialAccess.GetEntityById(id);
        }

        /// <summary>
        /// 获取BreedMaterial总条数
        /// </summary>
        /// <returns></returns>
        public int GetBreedMaterialCount()
        {
            return breedMaterialAccess.GetEntityCount();
        }

        public int GetBreedMaterialCount(string name)
        {
            int companyID = UserManagement.CurrentUser.CompanyId;
            return breedMaterialAccess.GetEntityCount(companyID, name);
        }

        public List<BreedMaterialModel> GetPagerBreedMaterial(string name, int pageIndex, int pageSize)
        {
            int companyID = UserManagement.CurrentUser.CompanyId;
            var result = breedMaterialAccess.GetPagerBreedMaterialByConditions(companyID, name.Trim(), pageIndex, pageSize);
            return result;
        }

        /// <summary>
        /// 插入单条BreedMaterial数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageModel InsertSingleBreedMaterial(BreedMaterialModel model)
        {
            return breedMaterialAccess.InsertSingleEntity(model);
        }

        /// <summary>
        /// 编辑单条BreedMaterial
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageModel UpdateSingleBreedMaterial(BreedMaterialModel model)
        {
            var data = breedMaterialAccess.GetOriEntity(model.MaterialID, model.ModifyTime);
            if (data == null) return new MessageModel() { Message = "当前数据不存在或被更新，请刷新后再次操作！", Status = MessageStatus.Error };
            return breedMaterialAccess.UpdateSingleEntity(model);
        }
    }
}
