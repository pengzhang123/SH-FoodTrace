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
    /// 养殖批次管理
    /// </summary>
    public class BreedBatchService : BaseService, IBreedBatchService
    {
        private IBreedBatchAccess breedBatchAccess;

        public BreedBatchService()
        {
            breedBatchAccess = BaseAccess.CreateAccess<IBreedBatchAccess>(AccessMappingKey.BreedBatchAccess.ToString());
        }

        /// <summary>
        /// 删除单条BreedBatch
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MessageModel DeleteSingleEntity(int id)
        {
            return breedBatchAccess.DeleteSingleEntity(id);
        }

        /// <summary>
        /// 通过ID获取BreedBatch
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BreedBatchModel GetBreedBatchById(int id)
        {
            return breedBatchAccess.GetEntityById(id);
        }

        /// <summary>
        /// 获取BreedBatch总条数
        /// </summary>
        /// <returns></returns>
        public int GetBreedBatchCount()
        {
            return breedBatchAccess.GetEntityCount();
        }

        public int GetBreedBatchCount(string name)
        {
            int companyID = UserManagement.CurrentUser.CompanyId;
            return breedBatchAccess.GetEntityCount(companyID, name);
        }

        public List<BreedBatchModel> GetPagerBreedBatch(string name, int pageIndex, int pageSize)
        {
            int companyID = UserManagement.CurrentUser.CompanyId;
            var result = breedBatchAccess.GetPagerBreedBatchByConditions(companyID, name.Trim(), pageIndex, pageSize);
            return result;
        }

        /// <summary>
        /// 插入单条BreedBatch数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageModel InsertSingleBreedBatch(BreedBatchModel model)
        {
            return breedBatchAccess.InsertSingleEntity(model);
        }

        /// <summary>
        /// 编辑单条BreedBatch
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageModel UpdateSingleBreedBatch(BreedBatchModel model)
        {
           
            return breedBatchAccess.UpdateSingleEntity(model);
        }
    }
}
