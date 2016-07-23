using FoodTrace.DBAccess;
using FoodTrace.IDBAccess;
using FoodTrace.IService;
using FoodTrace.Model;
using System;
using System.Collections.Generic;

namespace FoodTrace.Service
{
    /// <summary>
    /// 养殖用料视频管理
    /// </summary>
    public class BreedMaterialVideoService : BaseService, IBreedMaterialVideoService
    {
        private IBreedMaterialVideoAccess breedMaterialVideoAccess;

        public BreedMaterialVideoService()
        {
            breedMaterialVideoAccess = BaseAccess.CreateAccess<IBreedMaterialVideoAccess>(AccessMappingKey.BreedMaterialVideoAccess.ToString());
        }

        /// <summary>
        /// 删除单条BreedMaterialVideo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MessageModel DeleteSingleEntity(int id)
        {
            return breedMaterialVideoAccess.DeleteSingleEntity(id);
        }

        /// <summary>
        /// 通过ID获取BreedMaterialVideo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BreedMaterialVideoModel GetBreedMaterialVideoById(int id)
        {
            return breedMaterialVideoAccess.GetEntityById(id);
        }

        /// <summary>
        /// 获取BreedMaterialVideo总条数
        /// </summary>
        /// <returns></returns>
        public int GetBreedMaterialVideoCount()
        {
            return breedMaterialVideoAccess.GetEntityCount();
        }

        public int GetBreedMaterialVideoCount(string name)
        {
            throw new NotImplementedException();
        }

        public List<BreedMaterialVideoModel> GetPagerBreedMaterialVideo(string name, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 插入单条BreedMaterialVideo
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageModel InsertSingleBreedMaterialVideo(BreedMaterialVideoModel model)
        {
            return breedMaterialVideoAccess.InsertSingleEntity(model);
        }

        /// <summary>
        /// 编辑单条BreedMaterialVideo
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageModel UpdateSingleBreedMaterialVideo(BreedMaterialVideoModel model)
        {
            var data = breedMaterialVideoAccess.GetOriEntity(model.VideoID, model.ModifyTime);
            if (data == null) return new MessageModel() { Message = "当前数据不存在或被更新，请刷新后再次操作！", Status = MessageStatus.Error };
            return breedMaterialVideoAccess.UpdateSingleEntity(model);
        }
    }
}
