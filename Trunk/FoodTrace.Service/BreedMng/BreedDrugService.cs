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
    /// 养殖防疫管理
    /// </summary>
    public class BreedDrugService : BaseService, IBreedDrugService
    {
        private IBreedDrugAccess breedDrugAccess;

        public BreedDrugService()
        {
            breedDrugAccess = BaseAccess.CreateAccess<IBreedDrugAccess>(AccessMappingKey.BreedDrugAccess.ToString());
        }

        /// <summary>
        /// 删除单个BreedDrug
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MessageModel DeleteSingleEntity(int id)
        {
            return breedDrugAccess.DeleteSingleEntity(id);
        }

        /// <summary>
        /// 通过ID获取BreedDrug
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BreedDrugModel GetBreedDrugById(int id)
        {
            return breedDrugAccess.GetEntityById(id);
        }

        /// <summary>
        /// 获取BreedDrug总条数
        /// </summary>
        /// <returns></returns>
        public int GetBreedDrugCount()
        {
            return breedDrugAccess.GetEntityCount();
        }

        public int GetBreedDrugCount(string name)
        {
            int companyID = UserManagement.CurrentCompany.CompanyID;
            return breedDrugAccess.GetEntityCount(companyID, name);
        }

        public List<BreedDrugModel> GetPagerBreedDrug(string name, int pageIndex, int pageSize)
        {
            int companyID = UserManagement.CurrentCompany.CompanyID;
            var result = breedDrugAccess.GetPagerBreedDrugByConditions(companyID, name.Trim(), pageIndex, pageSize);
            return result;
        }

        /// <summary>
        /// 插入单条BreedDrug数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageModel InsertSingleBreedDrug(BreedDrugModel model)
        {
            return breedDrugAccess.InsertSingleEntity(model);
        }

        /// <summary>
        /// 更新单体BreedDrug
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageModel UpdateSingleBreedDrug(BreedDrugModel model)
        {
            var data = breedDrugAccess.GetOriEntity(model.DrugID, model.ModifyTime);
            if (data == null) return new MessageModel() { Message = "当前数据不存在或被更新，请刷新后再次操作！", Status = MessageStatus.Error };
            return breedDrugAccess.UpdateSingleEntity(model);
        }
    }
}
