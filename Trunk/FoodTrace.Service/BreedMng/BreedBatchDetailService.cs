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
    /// 养殖批管理
    /// </summary>
    public class BreedBatchDetailService : BaseService, IBreedBatchDetailService
    {
        private IBreedBatchDetailAccess breedBatchDetail;

        public BreedBatchDetailService()
        {
            breedBatchDetail = BaseAccess.CreateAccess<IBreedBatchDetailAccess>(AccessMappingKey.BreedBatchDetailAccess.ToString());
        }

        /// <summary>
        /// 删除单条BreedBatchDetail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MessageModel DeleteSingleEntity(int id)
        {
            return breedBatchDetail.DeleteSingleEntity(id);
        }

        /// <summary>
        /// 通过ID获取BreedBatchDetail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BreedBatchDetailModel GetBreedBatchDetailById(int id)
        {
            return breedBatchDetail.GetEntityById(id);
        }

        /// <summary>
        /// 获取BreedBatchDetail总条数
        /// </summary>
        /// <returns></returns>
        public int GetBreedBatchDetailCount()
        {
            return breedBatchDetail.GetEntityCount();
        }

        public int GetBreedBatchDetailCount(string name)
        {
            int companyID = UserManagement.CurrentCompany.CompanyID;
            return breedBatchDetail.GetEntityCount(companyID, name);
        }

        public List<BreedBatchDetailModel> GetPagerBreedBatchDetail(string name, int pageIndex, int pageSize)
        {
            int companyID = UserManagement.CurrentCompany.CompanyID;
            var result = breedBatchDetail.GetPagerBreedBatchDetailByConditions(companyID, name.Trim(), pageIndex, pageSize);
            return result;
        }

        /// <summary>
        /// 插入单体BreedBatchDetail数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageModel InsertSingleBreedBatchDetail(BreedBatchDetailModel model)
        {
            return breedBatchDetail.InsertSingleEntity(model);
        }

        /// <summary>
        /// 编辑单条BreedBatchDetail
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageModel UpdateSingleBreedBatchDetail(BreedBatchDetailModel model)
        {
            var data = breedBatchDetail.GetOriEntity(model.DetailID, model.ModifyTime);
            if (data == null) return new MessageModel() { Message = "当前数据不存在或被更新，请刷新后再次操作！", Status = MessageStatus.Error };
            return breedBatchDetail.UpdateSingleEntity(model);
        }
    }
}
