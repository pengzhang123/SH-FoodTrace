using FoodTrace.DBAccess;
using FoodTrace.IDBAccess;
using FoodTrace.IService;
using FoodTrace.Model;
using System;
using System.Collections.Generic;

namespace FoodTrace.Service
{
    /// <summary>
    /// 养殖防疫视频管理
    /// </summary>
    public class BreedDrugVideoService : BaseService, IBreedDrugVideoService
    {
        private IBreedDrugVideoAccess breedDrugVideoAccess;

        public BreedDrugVideoService()
        {
            breedDrugVideoAccess = BaseAccess.CreateAccess<IBreedDrugVideoAccess>(AccessMappingKey.BreedDrugVideoAccess.ToString());
        }

        /// <summary>
        /// 删除单条BreedDrugVideo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MessageModel DeleteSingleEntity(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 通过ID获取BreedDrugVideo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BreedDrugVideoModel GetBreedDrugVideoById(int id)
        {
            return breedDrugVideoAccess.GetEntityById(id);
        }

        /// <summary>
        /// 获取BreedDrugVideo总条数
        /// </summary>
        /// <returns></returns>
        public int GetBreedDrugVideoCount()
        {
            return breedDrugVideoAccess.GetEntityCount();
        }

        public int GetBreedDrugVideoCount(string name)
        {
            throw new NotImplementedException();
        }

        public List<BreedDrugVideoModel> GetPagerBreedDrugVideo(string name, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 插入单条BreedDrugVideo
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageModel InsertSingleBreedDrugVideo(BreedDrugVideoModel model)
        {
            return breedDrugVideoAccess.InsertSingleEntity(model);
        }

        /// <summary>
        /// 编辑单条BreedDrugVideo
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageModel UpdateSingleBreedDrugVideo(BreedDrugVideoModel model)
        {
            var data = breedDrugVideoAccess.GetOriEntity(model.VideoID, model.ModifyTime);
            if (data == null) return new MessageModel() { Message = "当前数据不存在或被更新，请刷新后再次操作！", Status = MessageStatus.Error };
            return breedDrugVideoAccess.UpdateSingleEntity(model);
        }
    }
}
